using RewardTormenta.Domain.Models;
using RewardTormenta.Infrastructure;

namespace RewardTormenta.Application;

/// <summary>
/// Provides random table lookups using the rules from the markdown source files.
/// </summary>
public class TreasureRoller
{
    private readonly Random _rng;

    public TreasureRoller(Random? rng = null)
    {
        _rng = rng ?? Random.Shared;
    }

    // ── Core helpers ─────────────────────────────────────────────────────────

    public int RollD100() => _rng.Next(1, 101);
    public int RollD6()   => _rng.Next(1, 7);

    private T? Lookup<T>(IReadOnlyList<T> table, int roll, Func<T, int> minRoll, Func<T, int> maxRoll)
    {
        return table.FirstOrDefault(e => roll >= minRoll(e) && roll <= maxRoll(e));
    }

    // ── Equipment ────────────────────────────────────────────────────────────

    public Weapon? RollWeapon(int? roll = null)
    {
        int r = roll ?? RollD100();
        return Lookup(Tables.Weapons, r, w => w.MinRoll, w => w.MaxRoll);
    }

    public Armor? RollArmor(int? roll = null)
    {
        int r = roll ?? RollD100();
        return Lookup(Tables.Armors, r, a => a.MinRoll, a => a.MaxRoll);
    }

    public EsotericItem? RollEsotericItem(int? roll = null)
    {
        int r = roll ?? RollD100();
        return Lookup(Tables.EsotericItems, r, e => e.MinRoll, e => e.MaxRoll);
    }

    // ── Misc items ───────────────────────────────────────────────────────────

    public MiscItem? RollMiscItem(int? roll = null)
    {
        int r = roll ?? RollD100();
        return Lookup(Tables.MiscItems, r, m => m.MinRoll, m => m.MaxRoll);
    }

    // ── Specific magic weapons ───────────────────────────────────────────────

    public SpecificWeapon? RollSpecificWeapon(int? roll = null)
    {
        int r = roll ?? RollD100();
        return Lookup(Tables.SpecificWeapons, r, w => w.MinRoll, w => w.MaxRoll);
    }

    // ── Weapon enchantment ───────────────────────────────────────────────────

    /// <summary>
    /// Rolls a random weapon enchantment.
    /// Re-rolls Energética, Lancinante, and Magnífica when called for minor items,
    /// as per the footnote in Armas_Mágicas.md.
    /// </summary>
    public WeaponEnchantment RollWeaponEnchantment(bool isMinorItem = false)
    {
        while (true)
        {
            int r = RollD100();
            WeaponEnchantment enchantment = r switch
            {
                >= 1   and <= 5   => WeaponEnchantment.Ameaçadora,
                >= 6   and <= 10  => WeaponEnchantment.Anticriatura,
                >= 11  and <= 12  => WeaponEnchantment.Arremesso,
                >= 13  and <= 14  => WeaponEnchantment.Assassina,
                >= 15  and <= 16  => WeaponEnchantment.Caçadora,
                >= 17  and <= 21  => WeaponEnchantment.Congelante,
                >= 22  and <= 23  => WeaponEnchantment.Conjuradora,
                >= 24  and <= 28  => WeaponEnchantment.Corrosiva,
                >= 29  and <= 30  => WeaponEnchantment.Dançarina,
                >= 31  and <= 34  => WeaponEnchantment.Defensora,
                >= 35  and <= 36  => WeaponEnchantment.Destruidora,
                >= 37  and <= 38  => WeaponEnchantment.Dilacerante,
                >= 39  and <= 40  => WeaponEnchantment.Drenante,
                >= 41  and <= 45  => WeaponEnchantment.Elétrica,
                46                => WeaponEnchantment.Energética,
                >= 47  and <= 48  => WeaponEnchantment.Excruciante,
                >= 49  and <= 53  => WeaponEnchantment.Flamejante,
                >= 54  and <= 63  => WeaponEnchantment.Formidável,
                64                => WeaponEnchantment.Lancinante,
                >= 65  and <= 72  => WeaponEnchantment.Magnífica,
                >= 73  and <= 74  => WeaponEnchantment.Piedosa,
                >= 75  and <= 76  => WeaponEnchantment.Profana,
                >= 77  and <= 78  => WeaponEnchantment.Sagrada,
                >= 79  and <= 80  => WeaponEnchantment.Sanguinária,
                >= 81  and <= 82  => WeaponEnchantment.Trovejante,
                >= 83  and <= 84  => WeaponEnchantment.Tumular,
                >= 85  and <= 88  => WeaponEnchantment.Veloz,
                >= 89  and <= 90  => WeaponEnchantment.Venenosa,
                _                 => WeaponEnchantment.ArmaEspecífica,
            };

            // Re-roll double-slot enchantments for minor items
            if (isMinorItem && enchantment is WeaponEnchantment.Energética
                                           or WeaponEnchantment.Lancinante
                                           or WeaponEnchantment.Magnífica)
                continue;

            return enchantment;
        }
    }

    // ── Special material ─────────────────────────────────────────────────────

    public SpecialMaterial RollSpecialMaterial()
    {
        int r = _rng.Next(1, 7);
        return (SpecialMaterial)r;
    }

    // ── Wealth ───────────────────────────────────────────────────────────────

    public Wealth? RollWealth(TreasureTier tier, int? roll = null)
    {
        int r = roll ?? RollD100();
        return Tables.Wealths
            .Where(w => w.Tier == tier && r >= w.MinRoll && r <= w.MaxRoll)
            .FirstOrDefault();
    }

    // ── Money amount resolution ───────────────────────────────────────────────

    /// <summary>
    /// Parses a MoneyDescription string and returns the rolled amount + currency.
    /// Handles direct dice expressions ("2d6x100 T$") and wealth-tier references
    /// ("1d3+1 riquezas médias").
    /// </summary>
    public (int Amount, string Currency) RollMoneyAmount(string description)
    {
        if (description.Contains("riqueza"))
            return RollWealthReference(description);

        return RollDirectDice(description);
    }

    private (int Amount, string Currency) RollDirectDice(string description)
    {
        int lastSpace     = description.LastIndexOf(' ');
        string currency   = description[(lastSpace + 1)..];
        string expression = description[..lastSpace];
        return (EvaluateDiceExpression(expression), currency);
    }

    private (int Amount, string Currency) RollWealthReference(string description)
    {
        string[] parts   = description.Split(' ');
        string countExpr = parts[0];
        string tierWord  = parts[^1];

        TreasureTier tier = tierWord switch
        {
            "menor"  or "menores" => TreasureTier.Menor,
            "média"  or "médias"  => TreasureTier.Média,
            "maior"  or "maiores" => TreasureTier.Maior,
            _ => throw new ArgumentException($"Unknown wealth tier: {tierWord}")
        };

        int count = countExpr.Contains('d')
            ? EvaluateDiceExpression(countExpr)
            : int.Parse(countExpr);

        int total = 0;
        for (int i = 0; i < count; i++)
        {
            var wealth = RollWealth(tier);
            if (wealth is not null)
                total += EvaluateDiceExpression(wealth.RollExpression);
        }

        return (total, "T$");
    }

    private int EvaluateDiceExpression(string expression)
    {
        int multiplier = 1;
        int xIndex     = expression.IndexOf('x');
        if (xIndex >= 0)
        {
            multiplier = int.Parse(expression[(xIndex + 1)..].Replace(".", ""));
            expression = expression[..xIndex];
        }

        int bonus     = 0;
        int plusIndex = expression.IndexOf('+');
        if (plusIndex >= 0)
        {
            bonus      = int.Parse(expression[(plusIndex + 1)..]);
            expression = expression[..plusIndex];
        }

        int dIndex  = expression.IndexOf('d');
        int numDice = int.Parse(expression[..dIndex]);
        int dieSize = int.Parse(expression[(dIndex + 1)..]);

        int total = bonus;
        for (int i = 0; i < numDice; i++)
            total += _rng.Next(1, dieSize + 1);

        return total * multiplier;
    }

    // ── Treasure by challenge rating ─────────────────────────────────────────

    /// <summary>
    /// Returns the money and item rows for the given challenge rating
    /// using two separate d100 rolls.
    /// </summary>
    /// <param name="challengeRating">e.g. "1/4", "1/2", "1", "2" … "20"</param>
    public (TreasureRow? moneyRow, TreasureRow? itemRow, int moneyRoll, int itemRoll) RollTreasure(string challengeRating)
    {
        if (!TreasureByChallenge.Table.TryGetValue(challengeRating, out var rows))
            throw new ArgumentException($"Unknown challenge rating: {challengeRating}", nameof(challengeRating));

        int moneyRoll = RollD100();
        int itemRoll  = RollD100();

        var moneyRow = rows.FirstOrDefault(r => moneyRoll >= r.MinMoneyRoll && moneyRoll <= r.MaxMoneyRoll);
        var itemRow  = rows.FirstOrDefault(r => itemRoll  >= r.MinItemRoll  && itemRoll  <= r.MaxItemRoll);

        return (moneyRow, itemRow, moneyRoll, itemRoll);
    }
}