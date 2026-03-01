namespace RewardTormenta.Domain.Models;

/// <summary>
/// Represents a standard weapon from the equipment table.
/// </summary>
public class Weapon
{
    public required string Name { get; init; }
    public int MinRoll { get; init; }
    public int MaxRoll { get; init; }
}

/// <summary>
/// Represents an armor or shield from the equipment table.
/// </summary>
public class Armor
{
    public required string Name { get; init; }
    public int MinRoll { get; init; }
    public int MaxRoll { get; init; }
}

/// <summary>
/// Represents an esoteric item from the equipment table.
/// </summary>
public class EsotericItem
{
    public required string Name { get; init; }
    public int MinRoll { get; init; }
    public int MaxRoll { get; init; }
}

/// <summary>
/// Represents a superior (improved) item with one or more improvements applied.
/// </summary>
public class SuperiorItem
{
    public required string BaseItemName { get; init; }
    public required string BaseItemType { get; init; } // "Arma", "Armadura", "Escudo", "Esotérico"
    public List<string> Improvements { get; init; } = [];
    public SpecialMaterial? SpecialMaterial { get; init; }

    public string Description =>
        $"{string.Join(", ", Improvements)} {BaseItemName}".Trim();
}

/// <summary>
/// Represents a specific (named) magic weapon from the Armas Específicas table.
/// </summary>
public class SpecificWeapon
{
    public required string Name { get; init; }
    public int Price { get; init; }
    public int MinRoll { get; init; }
    public int MaxRoll { get; init; }
}

/// <summary>
/// Represents an enchanted magic weapon with one or more enchantments.
/// </summary>
public class MagicWeapon
{
    public required string BaseWeaponName { get; init; }
    public List<WeaponEnchantment> Enchantments { get; init; } = [];
    public MagicItemTier Tier { get; init; }

    /// <summary>
    /// Total enchantment count — Energética, Lancinante, and Magnífica count as two.
    /// </summary>
    public int TotalEnchantmentSlots =>
        Enchantments.Sum(e => e is WeaponEnchantment.Energética
                              or WeaponEnchantment.Lancinante
                              or WeaponEnchantment.Magnífica ? 2 : 1);
}

/// <summary>
/// Represents a specific (named) magic armor from the Armaduras Específicas table.
/// </summary>
public class SpecificArmor
{
    public required string Name { get; init; }
    public int Price { get; init; }
    public int MinRoll { get; init; }
    public int MaxRoll { get; init; }
}

/// <summary>
/// Represents an enchanted magic armor or shield with one or more enchantments.
/// </summary>
public class MagicArmor
{
    public required string BaseArmorName { get; init; }
    public List<ArmorEnchantment> Enchantments { get; init; } = [];
    public MagicItemTier Tier { get; init; }

    /// <summary>
    /// Total enchantment count — Guardião counts as two.
    /// </summary>
    public int TotalEnchantmentSlots =>
        Enchantments.Sum(e => e is ArmorEnchantment.Guardião ? 2 : 1);
}