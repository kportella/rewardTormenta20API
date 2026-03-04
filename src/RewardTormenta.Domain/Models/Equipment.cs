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
        Enchantments.Sum(e => e is WeaponEnchantment.Energetica
                              or WeaponEnchantment.Lancinante
                              or WeaponEnchantment.Magnifica ? 2 : 1);
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
        Enchantments.Sum(e => e is ArmorEnchantment.Guardiao ? 2 : 1);
}

/// <summary>
/// Represents a potion from Tabela 8-12.
/// </summary>
public class Potion
{
    public required string Name { get; init; }
    public int Price { get; init; }   // value in T$
    public int MinRoll { get; init; }
    public int MaxRoll { get; init; }
}

/// <summary>
/// Represents a specific magic accessory from Tabelas 8-13, 8-14, and 8-15.
/// </summary>
public class Accessory
{
    public required string Name { get; init; }
    public int Price { get; init; }        // value in T$
    public MagicItemTier Tier { get; init; }
    public int MinRoll { get; init; }
    public int MaxRoll { get; init; }
}

/// <summary>
/// Wraps the fully-resolved result of a Mágico item roll.
/// Exactly one of the item fields will be non-null, indicated by <see cref="Type"/>.
/// Type values: "arma", "arma-específica", "armadura", "escudo", "armadura-específica", "acessório".
/// </summary>
public class ResolvedMagicItem
{
    public required string Type { get; init; }
    public int             TypeRoll         { get; init; }    // d6 roll that determined the type
    public List<int>       EnchantmentRolls { get; init; } = []; // d100 roll(s) for each enchantment
    public int?            ItemRoll         { get; init; }    // d100 roll for specific weapon/armor or accessory
    public MagicWeapon?    Weapon         { get; init; }
    public SpecificWeapon? SpecificWeapon { get; init; }
    public MagicArmor?     Armor          { get; init; }
    public SpecificArmor?  SpecificArmor  { get; init; }
    public Accessory?      Accessory      { get; init; }
}