namespace RewardTormenta.Domain.Models;

/// <summary>
/// Represents a wealth/treasure result from the Riquezas table.
/// </summary>
public class Wealth
{
    public TreasureTier Tier { get; init; }
    public required string RollExpression { get; init; }  // e.g. "4d4", "2d6x100"
    public int AverageValue { get; init; }                // value in T$
    public int MinRoll { get; init; }
    public int MaxRoll { get; init; }

    public override string ToString() => $"{RollExpression} T$ (~{AverageValue} T$)";
}

/// <summary>
/// Represents a miscellaneous item from the Itens Diversos table.
/// </summary>
public class MiscItem
{
    public required string Name { get; init; }
    public int MinRoll { get; init; }
    public int MaxRoll { get; init; }
}

/// <summary>
/// Represents the full loot result for an encounter at a given challenge rating.
/// </summary>
public class TreasureResult
{
    public int ChallengeRating { get; init; }
    public MoneyResult? Money { get; init; }
    public ItemResult? Item { get; init; }
}

public class MoneyResult
{
    public int Amount { get; init; }               // e.g. 650
    public required string Currency { get; init; } // "TC", "T$", or "TO"
    public int? Roll { get; init; }
}

public class PotionResult
{
    public required string Name { get; init; }
    public int Price { get; init; }
    public int Roll { get; init; }
}

public class EquipmentChoiceResult
{
    public int Die1 { get; init; }
    public int Die2 { get; init; }
    public required string Option1 { get; init; }
    public required string Option2 { get; init; }
}

public class ItemResult
{
    public required string Description { get; init; }   // e.g. "Diverso", "Superior (2 melhorias)"
    public bool HasRollBonus { get; init; }              // ⁺% modifier
    public bool HasDualRoll { get; init; }               // ²ᴰ modifier
    public int? Roll { get; init; }
    public string? Item { get; init; }                   // resolved misc item name (when Description == "Diverso")
    public int? MiscRoll { get; init; }                  // secondary d100 roll used to pick the misc item
    public List<PotionResult>? Potions { get; init; }    // resolved potions (when Description contains "poção")
    public EquipmentChoiceResult? EquipmentChoices { get; init; } // 2d6 type options (when Description == "Equipamento" or "Mágico")
}