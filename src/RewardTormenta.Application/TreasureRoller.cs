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

    /// <summary>
    /// Rolls a specific base equipment item for the given type label.
    /// </summary>
    public ResolvedEquipmentItem RollBaseEquipmentByType(string type)
    {
        string name = type switch
        {
            "arma"     => RollWeapon()?.Name       ?? "Desconhecida",
            "armadura" => RollArmor()?.Name        ?? "Desconhecida",
            "escudo"   => RollArmor()?.Name        ?? "Desconhecida",
            _          => RollEsotericItem()?.Name ?? "Desconhecida",
        };
        string pretty = type switch
        {
            "arma"     => "Arma",
            "armadura" => "Armadura",
            "escudo"   => "Escudo",
            _          => "Esotérico",
        };
        return new ResolvedEquipmentItem { Name = name, Type = pretty };
    }

    /// <summary>
    /// Rolls the equipment type (1d6) and resolves the specific base item.
    /// </summary>
    public ResolvedEquipmentItem RollBaseEquipment()
    {
        int die = RollD6();
        return RollBaseEquipmentByType(EquipmentTypeLabel(die));
    }

    /// <summary>
    /// Rolls for equipment category selection (1–4 arma, 5 armadura, 6 esotérico).
    /// When <paramref name="dualRoll"/> is <see langword="true"/>, rolls 2d6 and returns two options
    /// for the player to choose from. When <see langword="false"/>, rolls 1d6 and returns a single result.
    /// </summary>
    public EquipmentChoiceResult RollEquipment(bool dualRoll = true)
    {
        int die1 = RollD6();
        if (!dualRoll)
            return new EquipmentChoiceResult
            {
                Die1    = die1,
                Die2    = null,
                Option1 = EquipmentTypeLabel(die1),
                Option2 = null
            };

        int die2 = RollD6();
        return new EquipmentChoiceResult
        {
            Die1    = die1,
            Die2    = die2,
            Option1 = EquipmentTypeLabel(die1),
            Option2 = EquipmentTypeLabel(die2)
        };
    }

    private static string EquipmentTypeLabel(int roll) => roll switch
    {
        <= 3 => "arma",
        4    => "armadura",
        5    => "escudo",
        _    => "esoterico"
    };

    /// <summary>
    /// Rolls for magic item type selection (1–2 arma, 3 armadura/escudo, 4 acessório menor,
    /// 5 acessório médio, 6 acessório maior).
    /// When <paramref name="dualRoll"/> is <see langword="true"/>, rolls 2d6 and returns two options
    /// for the player to choose from. When <see langword="false"/>, rolls 1d6 and returns a single result.
    /// </summary>
    public EquipmentChoiceResult RollMagicItem(bool dualRoll = true)
    {
        int die1 = RollD6();
        if (!dualRoll)
            return new EquipmentChoiceResult
            {
                Die1    = die1,
                Die2    = null,
                Option1 = MagicItemTypeLabel(die1),
                Option2 = null
            };

        int die2 = RollD6();
        return new EquipmentChoiceResult
        {
            Die1    = die1,
            Die2    = die2,
            Option1 = MagicItemTypeLabel(die1),
            Option2 = MagicItemTypeLabel(die2)
        };
    }

    private static string MagicItemTypeLabel(int roll) => roll switch
    {
        <= 2 => "arma",
        3    => "armadura/escudo",
        4    => "acessorio menor",
        5    => "acessorio medio",
        _    => "acessorio maior"
    };

    // ── Superior item improvements ────────────────────────────────────────────

    private WeaponImprovement RollWeaponImprovement()
    {
        var values = Enum.GetValues<WeaponImprovement>();
        return values[_rng.Next(values.Length)];
    }

    private ArmorImprovement RollArmorImprovement()
    {
        var values = Enum.GetValues<ArmorImprovement>();
        return values[_rng.Next(values.Length)];
    }

    private EsotericImprovement RollEsotericImprovement()
    {
        var values = Enum.GetValues<EsotericImprovement>();
        return values[_rng.Next(values.Length)];
    }

    /// <summary>
    /// Fully resolves a Superior item: rolls equipment type (1d6) then delegates to
    /// <see cref="RollSuperiorItemByType"/>.
    /// </summary>
    public SuperiorItem RollSuperiorItem(int slots)
    {
        int die    = RollD6();
        return RollSuperiorItemByType(EquipmentTypeLabel(die), slots);
    }

    /// <summary>
    /// Resolves a Superior item for the given <paramref name="type"/> and slot count.
    /// Valid type values: "arma", "armadura", "escudo", "esoterico".
    /// Double-slot improvements (Atroz/Pungente for weapons, SobMedida for armor) may exceed
    /// the slot budget by 1 — this is intentional.
    /// </summary>
    public SuperiorItem RollSuperiorItemByType(string type, int slots)
    {
        // 1. Roll base item
        string baseItemName;
        string baseItemType;
        switch (type)
        {
            case "arma":
                baseItemName = RollWeapon()?.Name ?? "Desconhecida";
                baseItemType = "Arma";
                break;
            case "armadura":
                baseItemName = RollArmor()?.Name ?? "Desconhecida";
                baseItemType = "Armadura";
                break;
            case "escudo":
                baseItemName = RollArmor()?.Name ?? "Desconhecida";
                baseItemType = "Escudo";
                break;
            default: // "esoterico"
                baseItemName = RollEsotericItem()?.Name ?? "Desconhecida";
                baseItemType = "Esoterico";
                break;
        }

        // 2. Roll improvements until slots are filled
        var improvements         = new List<string>();
        SpecialMaterial? material = null;
        int slotsUsed            = 0;

        while (slotsUsed < slots)
        {
            switch (type)
            {
                case "arma":
                {
                    var imp = RollWeaponImprovement();
                    improvements.Add(imp.ToString());
                    if (imp is WeaponImprovement.MaterialEspecial)
                        material = RollSpecialMaterial();
                    slotsUsed += imp is WeaponImprovement.Atroz or WeaponImprovement.Pungente ? 2 : 1;
                    break;
                }
                case "armadura" or "escudo":
                {
                    var imp = RollArmorImprovement();
                    improvements.Add(imp.ToString());
                    if (imp is ArmorImprovement.MaterialEspecial)
                        material = RollSpecialMaterial();
                    slotsUsed += imp is ArmorImprovement.SobMedida ? 2 : 1;
                    break;
                }
                default: // "esoterico"
                {
                    var imp = RollEsotericImprovement();
                    improvements.Add(imp.ToString());
                    if (imp is EsotericImprovement.MaterialEspecial)
                        material = RollSpecialMaterial();
                    slotsUsed += 1;
                    break;
                }
            }
        }

        return new SuperiorItem
        {
            BaseItemName    = baseItemName,
            BaseItemType    = baseItemType,
            Improvements    = improvements,
            SpecialMaterial = material
        };
    }

    // ── Misc items ───────────────────────────────────────────────────────────

    public MiscItem? RollMiscItem(int? roll = null)
    {
        int r = roll ?? RollD100();
        return Lookup(Tables.MiscItems, r, m => m.MinRoll, m => m.MaxRoll);
    }

    // ── Potions ──────────────────────────────────────────────────────────────

    public Potion? RollPotion(int? roll = null)
    {
        int r = roll ?? RollD100();
        return Lookup(Tables.Potions, r, p => p.MinRoll, p => p.MaxRoll);
    }

    /// <summary>
    /// Parses a potion count description (e.g. "1 poção", "1d3 poções", "1d4+1 poções")
    /// and returns one rolled potion per count.
    /// </summary>
    public List<(Potion Potion, int Roll)> RollPotions(string description)
    {
        string countExpr = description.Split(' ')[0];
        int count = countExpr.Contains('d')
            ? EvaluateDiceExpression(countExpr)
            : int.Parse(countExpr);

        var results = new List<(Potion, int)>(count);
        for (int i = 0; i < count; i++)
        {
            int roll = RollD100();
            var potion = RollPotion(roll);
            if (potion is not null)
                results.Add((potion, roll));
        }
        return results;
    }

    // ── Accessories ──────────────────────────────────────────────────────────

    public Accessory? RollAccessory(MagicItemTier tier, int? roll = null)
    {
        int r = roll ?? RollD100();
        return Tables.Accessories
            .Where(a => a.Tier == tier && r >= a.MinRoll && r <= a.MaxRoll)
            .FirstOrDefault();
    }

    // ── Specific magic weapons ───────────────────────────────────────────────

    public SpecificWeapon? RollSpecificWeapon(int? roll = null)
    {
        int r = roll ?? RollD100();
        return Lookup(Tables.SpecificWeapons, r, w => w.MinRoll, w => w.MaxRoll);
    }

    // ── Specific magic armors ────────────────────────────────────────────────

    public SpecificArmor? RollSpecificArmor(int? roll = null)
    {
        int r = roll ?? RollD100();
        return Lookup(Tables.SpecificArmors, r, a => a.MinRoll, a => a.MaxRoll);
    }

    // ── Weapon enchantment ───────────────────────────────────────────────────

    /// <summary>
    /// Rolls a random weapon enchantment.
    /// Re-rolls Energética, Lancinante, and Magnífica when called for minor items,
    /// as per the footnote in Armas_Mágicas.md.
    /// </summary>
    public (WeaponEnchantment Enchantment, int Roll) RollWeaponEnchantment(bool isMinorItem = false)
    {
        while (true)
        {
            int r = RollD100();
            WeaponEnchantment enchantment = r switch
            {
                >= 1   and <= 5   => WeaponEnchantment.Ameacadora,
                >= 6   and <= 10  => WeaponEnchantment.Anticriatura,
                >= 11  and <= 12  => WeaponEnchantment.Arremesso,
                >= 13  and <= 14  => WeaponEnchantment.Assassina,
                >= 15  and <= 16  => WeaponEnchantment.Cacadora,
                >= 17  and <= 21  => WeaponEnchantment.Congelante,
                >= 22  and <= 23  => WeaponEnchantment.Conjuradora,
                >= 24  and <= 28  => WeaponEnchantment.Corrosiva,
                >= 29  and <= 30  => WeaponEnchantment.Dancarina,
                >= 31  and <= 34  => WeaponEnchantment.Defensora,
                >= 35  and <= 36  => WeaponEnchantment.Destruidora,
                >= 37  and <= 38  => WeaponEnchantment.Dilacerante,
                >= 39  and <= 40  => WeaponEnchantment.Drenante,
                >= 41  and <= 45  => WeaponEnchantment.Eletrica,
                46                => WeaponEnchantment.Energetica,
                >= 47  and <= 48  => WeaponEnchantment.Excruciante,
                >= 49  and <= 53  => WeaponEnchantment.Flamejante,
                >= 54  and <= 63  => WeaponEnchantment.Formidavel,
                64                => WeaponEnchantment.Lancinante,
                >= 65  and <= 72  => WeaponEnchantment.Magnifica,
                >= 73  and <= 74  => WeaponEnchantment.Piedosa,
                >= 75  and <= 76  => WeaponEnchantment.Profana,
                >= 77  and <= 78  => WeaponEnchantment.Sagrada,
                >= 79  and <= 80  => WeaponEnchantment.Sanguinaria,
                >= 81  and <= 82  => WeaponEnchantment.Trovejante,
                >= 83  and <= 84  => WeaponEnchantment.Tumular,
                >= 85  and <= 88  => WeaponEnchantment.Veloz,
                >= 89  and <= 90  => WeaponEnchantment.Venenosa,
                _                 => WeaponEnchantment.ArmaEspecifica,
            };

            // Re-roll double-slot enchantments for minor items
            if (isMinorItem && enchantment is WeaponEnchantment.Energetica
                                           or WeaponEnchantment.Lancinante
                                           or WeaponEnchantment.Magnifica)
                continue;

            return (enchantment, r);
        }
    }

    // ── Armor enchantment ────────────────────────────────────────────────────

    /// <summary>
    /// Rolls a random armor enchantment from Tabela 8-10.
    /// Re-rolls Guardião for minor items (footnote ²).
    /// Re-rolls Animado and Esmagador for non-shield armors (footnote ¹).
    /// </summary>
    public (ArmorEnchantment Enchantment, int Roll) RollArmorEnchantment(bool isMinorItem = false, bool isShield = false)
    {
        while (true)
        {
            int r = RollD100();
            ArmorEnchantment enchantment = r switch
            {
                >= 1  and <= 6  => ArmorEnchantment.Abascanto,
                >= 7  and <= 10 => ArmorEnchantment.Abencoado,
                >= 11 and <= 12 => ArmorEnchantment.Acrobatico,
                >= 13 and <= 14 => ArmorEnchantment.Alado,
                >= 15 and <= 16 => ArmorEnchantment.Animado,
                >= 17 and <= 18 => ArmorEnchantment.Assustador,
                >= 19 and <= 22 => ArmorEnchantment.Caustica,
                >= 23 and <= 32 => ArmorEnchantment.Defensor,
                >= 33 and <= 34 => ArmorEnchantment.Escorregadio,
                >= 35 and <= 36 => ArmorEnchantment.Esmagador,
                >= 37 and <= 38 => ArmorEnchantment.Fantasmagorico,
                >= 39 and <= 40 => ArmorEnchantment.Fortificado,
                >= 41 and <= 44 => ArmorEnchantment.Gelido,
                >= 45 and <= 54 => ArmorEnchantment.Guardiao,
                >= 55 and <= 56 => ArmorEnchantment.Hipnotico,
                >= 57 and <= 58 => ArmorEnchantment.Ilusorio,
                >= 59 and <= 62 => ArmorEnchantment.Incandescente,
                >= 63 and <= 68 => ArmorEnchantment.Invulneravel,
                >= 69 and <= 72 => ArmorEnchantment.Opaco,
                >= 73 and <= 78 => ArmorEnchantment.Protetor,
                >= 79 and <= 80 => ArmorEnchantment.Refletor,
                >= 81 and <= 84 => ArmorEnchantment.Relampejante,
                >= 85 and <= 86 => ArmorEnchantment.Reluzente,
                >= 87 and <= 88 => ArmorEnchantment.Sombrio,
                >= 89 and <= 90 => ArmorEnchantment.Zeloso,
                _               => ArmorEnchantment.ItemEspecifico,
            };

            if (isMinorItem && enchantment is ArmorEnchantment.Guardiao)
                continue;

            if (!isShield && enchantment is ArmorEnchantment.Animado or ArmorEnchantment.Esmagador)
                continue;

            return (enchantment, r);
        }
    }

    // ── Magic item full resolution ────────────────────────────────────────────

    /// <summary>
    /// Fully resolves a Mágico item: rolls type (1d6), then delegates to
    /// <see cref="RollMagicItemByType"/> with the rolled die value.
    /// </summary>
    public ResolvedMagicItem RollMagicItemFull(MagicItemTier tier)
    {
        int die    = RollD6();
        string type = MagicItemTypeLabel(die);
        return RollMagicItemByType(type, tier, typeRoll: die);
    }

    /// <summary>
    /// Resolves a magic item for the given <paramref name="type"/> string and tier.
    /// <paramref name="typeRoll"/> is the d6 value that produced the type (0 when user-chosen).
    /// Valid type values: "arma", "armadura/escudo", "acessorio menor", "acessorio medio", "acessorio maior".
    /// </summary>
    public ResolvedMagicItem RollMagicItemByType(string type, MagicItemTier tier, int typeRoll = 0)
    {
        bool isMinor = tier is MagicItemTier.Menor;
        int slots    = tier switch
        {
            MagicItemTier.Menor => 1,
            MagicItemTier.Medio => 2,
            _                   => 3  // Maior
        };

        switch (type)
        {
            case "arma":
            {
                // First roll determines the path: specific weapon OR enchanted weapon
                var (firstEnch, firstRoll) = RollWeaponEnchantment(isMinor);
                if (firstEnch is WeaponEnchantment.ArmaEspecifica)
                {
                    int itemRoll = RollD100();
                    return new ResolvedMagicItem
                    {
                        Type             = "arma-específica",
                        TypeRoll         = typeRoll,
                        EnchantmentRolls = [firstRoll],
                        ItemRoll         = itemRoll,
                        SpecificWeapon   = RollSpecificWeapon(itemRoll)
                    };
                }

                // Enchanted weapon — fill remaining slots (re-roll ArmaEspecífica)
                var enchantments     = new List<WeaponEnchantment> { firstEnch };
                var enchantmentRolls = new List<int> { firstRoll };
                int slotsUsed        = firstEnch is WeaponEnchantment.Energetica
                                                  or WeaponEnchantment.Lancinante
                                                  or WeaponEnchantment.Magnifica ? 2 : 1;

                while (slotsUsed < slots)
                {
                    var (enc, encRoll) = RollWeaponEnchantment(isMinor);
                    if (enc is WeaponEnchantment.ArmaEspecifica) continue;
                    enchantments.Add(enc);
                    enchantmentRolls.Add(encRoll);
                    slotsUsed += enc is WeaponEnchantment.Energetica
                                       or WeaponEnchantment.Lancinante
                                       or WeaponEnchantment.Magnifica ? 2 : 1;
                }

                return new ResolvedMagicItem
                {
                    Type             = "arma",
                    TypeRoll         = typeRoll,
                    EnchantmentRolls = enchantmentRolls,
                    Weapon           = new MagicWeapon
                    {
                        BaseWeaponName = RollWeapon()?.Name ?? "Desconhecida",
                        Enchantments   = enchantments,
                        Tier           = tier
                    }
                };
            }

            case "armadura/escudo":
            {
                // Roll base item first to determine if it's a shield
                var baseArmor = RollArmor();
                bool isShield = baseArmor?.Name.Contains("Escudo") ?? false;

                // First roll determines the path: specific armor OR enchanted armor/shield
                var (firstEnch, firstRoll) = RollArmorEnchantment(isMinor, isShield);
                if (firstEnch is ArmorEnchantment.ItemEspecifico)
                {
                    int itemRoll = RollD100();
                    return new ResolvedMagicItem
                    {
                        Type             = "armadura-específica",
                        TypeRoll         = typeRoll,
                        EnchantmentRolls = [firstRoll],
                        ItemRoll         = itemRoll,
                        SpecificArmor    = RollSpecificArmor(itemRoll)
                    };
                }

                var enchantments     = new List<ArmorEnchantment> { firstEnch };
                var enchantmentRolls = new List<int> { firstRoll };
                int slotsUsed        = firstEnch is ArmorEnchantment.Guardiao ? 2 : 1;

                while (slotsUsed < slots)
                {
                    var (enc, encRoll) = RollArmorEnchantment(isMinor, isShield);
                    if (enc is ArmorEnchantment.ItemEspecifico) continue;
                    enchantments.Add(enc);
                    enchantmentRolls.Add(encRoll);
                    slotsUsed += enc is ArmorEnchantment.Guardiao ? 2 : 1;
                }

                return new ResolvedMagicItem
                {
                    Type             = isShield ? "escudo" : "armadura",
                    TypeRoll         = typeRoll,
                    EnchantmentRolls = enchantmentRolls,
                    Armor            = new MagicArmor
                    {
                        BaseArmorName = baseArmor?.Name ?? "Desconhecida",
                        Enchantments  = enchantments,
                        Tier          = tier
                    }
                };
            }

            case "acessorio menor":
            case "acessorio medio":
            default: // "acessorio maior"
            {
                var accessoryTier = type switch
                {
                    "acessorio menor" => MagicItemTier.Menor,
                    "acessorio medio" => MagicItemTier.Medio,
                    _                 => MagicItemTier.Maior
                };
                int itemRoll = RollD100();
                return new ResolvedMagicItem
                {
                    Type      = "acessório",
                    TypeRoll  = typeRoll,
                    ItemRoll  = itemRoll,
                    Accessory = RollAccessory(accessoryTier, itemRoll)
                };
            }
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
            "media"  or "medias"  => TreasureTier.Media,
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