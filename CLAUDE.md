# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build Commands

```bash
# Restore dependencies
dotnet restore

# Build all projects
dotnet build

# Run the API
dotnet run --project src/RewardTormenta.Api

# Run tests (when tests are added)
dotnet test
```

## Architecture

This is a .NET 8 Web API for generating random treasure/loot for the Tormenta 20 tabletop RPG system. The solution follows Clean Architecture with four layers:

- **RewardTormenta.Api** - ASP.NET Core Web API with Swagger/OpenAPI support. Minimal API style with three endpoints defined in `Program.cs`.
- **RewardTormenta.Application** - Business logic in `TreasureRoller` which implements dice-based random table lookups for treasure, superior items, and magic items.
- **RewardTormenta.Domain** - Domain models for equipment, treasure results, and enums for enchantments, improvements, materials, and tiers (`Models/Equipment.cs`, `Models/Treasure.cs`, `Models/Enums.cs`).
- **RewardTormenta.Infrastructure** - Static lookup tables (`Tables.cs`) containing all equipment, misc items, specific weapons/armors, accessories, potions, and wealth data derived from Tormenta 20 rulebooks.

## API Endpoints

### `GET /treasure?challengeRating={cr}` (repeatable)
Rolls treasure for one or more challenge ratings. Returns `TreasureResult[]` with money and item results. Auto-resolves Superior and Mágico items when `ItemHasDualRoll=false`; returns `EquipmentChoiceResult` (2d6 options) when `ItemHasDualRoll=true`.

### `GET /roll/magicItem?type={type}&tier={tier}`
Manually resolves a magic item by type and tier. Use when `/treasure` returned `EquipmentChoiceResult` and the user chose a type.
- `type`: `arma`, `armadura/escudo`, `acessorio menor`, `acessorio medio`, `acessorio maior`
- `tier`: `Menor`, `Medio`, `Maior`

### `GET /roll/equipment?type={type}&improvements={n}`
Manually resolves a superior item by type with `n` improvements (1–4). Use when `/treasure` returned `EquipmentChoiceResult` and the user chose a type.
- `type`: `arma`, `armadura`, `escudo`, `esoterico`

## Key Concepts

The treasure system uses d100 rolls against probability tables indexed by Challenge Rating (ND 1/4 through 20). Results can include:
- Currency (TC = copper, T$ = silver, TO = gold)
- Miscellaneous items (consumables, equipment) — `ItemResult.Item`
- Potions — `ItemResult.Potions` (list of `PotionResult`)
- Superior items — base equipment with improvements; auto-resolved as `ResolvedSuperiorItem` or user-chosen via `EquipmentChoices`
- Magic items — enchanted weapons/armors/accessories by tier (Menor/Médio/Maior); auto-resolved as `ResolvedMagicItem` or user-chosen via `EquipmentChoices`

### ItemResult flags
- `HasDualRoll` (²ᴰ): player rolls two dice and picks — returns `EquipmentChoiceResult` for user to choose type, then call `/roll/equipment` or `/roll/magicItem`
- `HasRollBonus` (⁺%): player rolls with a bonus

### Enchantment slot rules
- Weapons: `Energetica`, `Lancinante`, `Magnifica` count as **2 slots**
- Armor/Shield: `Guardiao` counts as **2 slots**; `Animado` and `Esmagador` are shield-only (reroll for armor)

## Language

Enum values use ASCII-safe Portuguese (no accents) matching stripped Tormenta 20 names (e.g., `WeaponEnchantment.Flamejante`, `ArmorEnchantment.Guardiao`, `MagicItemTier.Medio`). Display strings in tables/descriptions may retain accents.
