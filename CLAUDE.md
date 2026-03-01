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

- **RewardTormenta.Api** - ASP.NET Core Web API with Swagger/OpenAPI support. Currently contains the default weather forecast endpoint as a template.
- **RewardTormenta.Application** - Business logic including `TreasureRoller` which implements dice-based random table lookups for treasure generation.
- **RewardTormenta.Domain** - Domain models representing equipment (weapons, armor, esoteric items), treasure results, and enums for enchantments, improvements, materials, and tiers.
- **RewardTormenta.Infrastructure** - Static lookup tables (`Tables.cs`) containing all equipment, misc items, specific weapons, and wealth data derived from Tormenta 20 rulebooks.

## Key Concepts

The treasure system uses d100 rolls against probability tables indexed by Challenge Rating (ND 1/4 through 20). Results can include:
- Currency (TC = copper, T$ = silver, TO = gold)
- Miscellaneous items (consumables, equipment)
- Superior items (base equipment with improvements)
- Magic items (enchanted weapons by tier: Menor/Médio/Maior)

Enchantments like Energética, Lancinante, and Magnífica count as two slots when applied to weapons.

## Language

Domain models and enum values use Portuguese names matching the Tormenta 20 rulebook (e.g., `WeaponEnchantment.Flamejante`, `TreasureTier.Menor`).
