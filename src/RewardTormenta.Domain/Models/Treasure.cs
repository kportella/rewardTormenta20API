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
    public required string Description { get; init; }   // e.g. "1d6x10 TC", "1 riqueza menor"
    public int? MinRoll { get; init; }
    public int? MaxRoll { get; init; }
}

public class ItemResult
{
    public required string Description { get; init; }   // e.g. "Diverso", "Superior (2 melhorias)"
    public bool HasRollBonus { get; init; }              // ⁺% modifier
    public bool HasDualRoll { get; init; }               // ²ᴰ modifier
    public int? MinRoll { get; init; }
    public int? MaxRoll { get; init; }
}