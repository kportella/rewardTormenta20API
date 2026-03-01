namespace RewardTormenta.Domain.Models;

/// <summary>
/// Represents one row in the "Tesouro por Nível de Desafio" table.
/// </summary>
public record TreasureRow(
    int MinMoneyRoll,
    int MaxMoneyRoll,
    string MoneyDescription,
    bool MoneyHasRollBonus,
    int MinItemRoll,
    int MaxItemRoll,
    string ItemDescription,
    bool ItemHasRollBonus,
    bool ItemHasDualRoll
);

/// <summary>
/// Full treasure table indexed by Challenge Rating (ND).
/// CR 1/4 → key 0, CR 1/2 → key -1 (use the lookup method instead of direct indexing).
/// </summary>
public static class TreasureByChallenge
{
    /// <summary>
    /// All entries for each Challenge Rating.
    /// Key: challenge rating as a string ("1/4", "1/2", "1" … "20").
    /// </summary>
    public static readonly IReadOnlyDictionary<string, IReadOnlyList<TreasureRow>> Table =
        new Dictionary<string, IReadOnlyList<TreasureRow>>
        {
            ["1/4"] =
            [
                new(1,  30,  "—",            false, 1,  50,  "—",          false, false),
                new(31, 70,  "1d6x10 TC",    false, 51, 75,  "Diverso",    false, false),
                new(71, 95,  "1d4x100 TC",   false, 76, 100, "Equipamento",false, false),
                new(96, 100, "1d6x10 T$",    false, 0,  0,   "",           false, false),
            ],
            ["1/2"] =
            [
                new(1,  25,  "—",            false, 1,  45,  "—",          false, false),
                new(26, 70,  "2d6x10 TC",    false, 46, 70,  "Diverso",    false, false),
                new(71, 95,  "2d8x10 T$",    false, 71, 100, "Equipamento",false, false),
                new(96, 100, "1d4x100 T$",   false, 0,  0,   "",           false, false),
            ],
            ["1"] =
            [
                new(1,  20,  "—",            false, 1,  40,  "—",          false, false),
                new(21, 70,  "3d8x10 T$",    false, 41, 65,  "Diverso",    false, false),
                new(71, 95,  "4d12x10 T$",   false, 66, 90,  "Equipamento",false, false),
                new(96, 100, "1 riqueza menor", false, 91,100,"1 poção",    false, false),
            ],
            ["2"] =
            [
                new(1,  15,  "—",            false, 1,  30,  "—",                   false, false),
                new(16, 55,  "3d10x10 T$",   false, 31, 40,  "Diverso",             false, false),
                new(56, 85,  "2d4x100 T$",   false, 41, 70,  "Equipamento",         false, false),
                new(86, 95,  "2d6+1x100 T$", false, 71, 90,  "1 poção",             false, false),
                new(96, 100, "1 riqueza menor",false,91, 100, "Superior (1 melhoria)",false,false),
            ],
            ["3"] =
            [
                new(1,  10,  "—",              false, 1,  25,  "—",                   false, false),
                new(11, 20,  "4d12x10 T$",     false, 26, 35,  "Diverso",             false, false),
                new(21, 60,  "1d4x100 T$",     false, 36, 60,  "Equipamento",         false, false),
                new(61, 90,  "1d8x10 TO",      false, 61, 85,  "1 poção",             false, false),
                new(91, 100, "1d3 riquezas menores",false,86,100,"Superior (1 melhoria)",false,false),
            ],
            ["4"] =
            [
                new(1,  10,  "—",                    false, 1,  20,  "—",                    false, false),
                new(11, 50,  "1d6x100 T$",           false, 21, 30,  "Diverso",              false, false),
                new(51, 80,  "1d12x100 T$",          false, 31, 55,  "Equipamento",          false, true),
                new(81, 90,  "1 riqueza menor",       true,  56, 80,  "1 poção",              true,  false),
                new(91, 100, "1d3 riquezas menores",  true,  81, 100, "Superior (1 melhoria)",false, true),
            ],
            ["5"] =
            [
                new(1,  15,  "—",             false, 1,  20,  "—",                    false, false),
                new(16, 65,  "1d8x100 T$",    false, 21, 70,  "1 poção",              false, false),
                new(66, 95,  "3d4x10 TO",     false, 71, 90,  "Superior (1 melhoria)",false, false),
                new(96, 100, "1 riqueza média",false, 91, 100, "Superior (2 melhorias)",false,false),
            ],
            ["6"] =
            [
                new(1,  15,  "—",                       false, 1,  20,  "—",                    false, false),
                new(16, 60,  "2d6x100 T$",              false, 21, 65,  "1 poção",              true,  false),
                new(61, 90,  "2d10x100 T$",             false, 66, 95,  "Superior (1 melhoria)",false, false),
                new(91, 100, "1d3+1 riquezas menores",  false, 96, 100, "Superior (2 melhorias)",false,true),
            ],
            ["7"] =
            [
                new(1,  10,  "—",                     false, 1,  20,  "—",                    false, false),
                new(11, 60,  "2d8x100 T$",            false, 21, 60,  "1d3 poções",           false, false),
                new(61, 90,  "2d12x10 TO",            false, 61, 90,  "Superior (2 melhorias)",false,false),
                new(91, 100, "1d4+1 riquezas menores",false, 91, 100, "Superior (3 melhorias)",false,false),
            ],
            ["8"] =
            [
                new(1,  10,  "—",                    false, 1,  20,  "—",                    false, false),
                new(11, 55,  "2d10x100 T$",          false, 21, 75,  "1d3 poções",           false, false),
                new(56, 95,  "1d4+1 riquezas menores",false,76, 95,  "Superior (2 melhorias)",false,false),
                new(96, 100, "1 riqueza média",       true,  96, 100, "Superior (3 melhorias)",false,true),
            ],
            ["9"] =
            [
                new(1,  10,  "—",                  false, 1,  20,  "—",                    false, false),
                new(11, 35,  "1 riqueza média",     false, 21, 70,  "1 poção",              true,  false),
                new(36, 85,  "4d6x100 T$",          false, 71, 95,  "Superior (3 melhorias)",false,false),
                new(86, 100, "1d3 riquezas médias", false, 96, 100, "Mágico (menor)",       false, false),
            ],
            ["10"] =
            [
                new(1,  10,  "—",                    false, 1,  50,  "—",                    false, false),
                new(11, 30,  "4d6x100 T$",           false, 51, 75,  "1d3+1 poções",         false, false),
                new(31, 85,  "4d10x10 TO",           false, 76, 90,  "Superior (3 melhorias)",false,false),
                new(86, 100, "1d3+1 riquezas médias",false, 91, 100, "Mágico (menor)",       false, false),
            ],
            ["11"] =
            [
                new(1,  10,  "—",                  false, 1,  45,  "—",                    false, false),
                new(11, 45,  "2d4x1.000 T$",       false, 46, 70,  "1d4+1 poções",         false, false),
                new(46, 85,  "1d3 riquezas médias", false, 71, 90,  "Superior (3 melhorias)",false,false),
                new(86, 100, "2d6x100 TO",          false, 91, 100, "Mágico (menor)",       false, true),
            ],
            ["12"] =
            [
                new(1,  10,  "—",                    false, 1,  45,  "—",                    false, false),
                new(11, 45,  "1 riqueza média",       true,  46, 70,  "1d3+1 poções",         true,  false),
                new(46, 80,  "2d6x1.000 T$",         false, 71, 85,  "Superior (4 melhorias)",false,false),
                new(81, 100, "1d4+1 riquezas médias", false, 86, 100, "Mágico (menor)",       false, false),
            ],
            ["13"] =
            [
                new(1,  10,  "—",                    false, 1,  40,  "—",                    false, false),
                new(11, 45,  "4d4x1.000 T$",         false, 41, 65,  "1d4+1 poções",         true,  false),
                new(46, 80,  "1d3+1 riquezas médias",false, 66, 95,  "Superior (4 melhorias)",false,false),
                new(81, 100, "4d6x100 TO",            false, 96, 100, "Mágico (médio)",        false, false),
            ],
            ["14"] =
            [
                new(1,  10,  "—",                    false, 1,  40,  "—",                    false, false),
                new(11, 45,  "1d3+1 riquezas médias",false, 41, 65,  "1d4+1 poções",         true,  false),
                new(46, 80,  "3d6x1.000 T$",         false, 66, 90,  "Superior (4 melhorias)",false,false),
                new(81, 100, "1 riqueza maior",       false, 91, 100, "Mágico (médio)",        false, false),
            ],
            ["15"] =
            [
                new(1,  10,  "—",                    false, 1,  35,  "—",                    false, false),
                new(11, 45,  "1 riqueza média",       true,  36, 45,  "1d6+1 poções",         false, false),
                new(46, 80,  "2d10x1.000 T$",        false, 46, 85,  "Superior (4 melhorias)",false,true),
                new(81, 100, "1d4x1.000 TO",          false, 86, 100, "Mágico (médio)",        false, false),
            ],
            ["16"] =
            [
                new(1,  10,  "—",                  false, 1,  35,  "—",                    false, false),
                new(11, 40,  "3d6x1.000 T$",       false, 36, 45,  "1d6+1 poções",         true,  false),
                new(41, 75,  "3d10x100 TO",         false, 46, 80,  "Superior (4 melhorias)",false,true),
                new(76, 100, "1d3 riquezas maiores",false, 81, 100, "Mágico (médio)",        false, false),
            ],
            ["17"] =
            [
                new(1,  5,   "—",                    false, 1,  20,  "—",              false, false),
                new(6,  40,  "4d6x1.000 T$",         false, 21, 40,  "Mágico (menor)", false, false),
                new(41, 75,  "1d3 riquezas médias",  true,  41, 80,  "Mágico (médio)", false, false),
                new(76, 100, "2d4x1.000 TO",          false, 81, 100, "Mágico (maior)", false, false),
            ],
            ["18"] =
            [
                new(1,  5,   "—",                      false, 1,  15,  "—",              false, false),
                new(6,  40,  "4d10x1.000 T$",          false, 16, 40,  "Mágico (menor)", false, true),
                new(41, 75,  "1 riqueza maior",         false, 41, 70,  "Mágico (médio)", false, false),
                new(76, 100, "1d3+1 riquezas maiores",  false, 71, 100, "Mágico (maior)", false, false),
            ],
            ["19"] =
            [
                new(1,  5,   "—",                    false, 1,  10,  "—",              false, false),
                new(6,  40,  "4d12x1.000 T$",        false, 11, 40,  "Mágico (menor)", false, true),
                new(41, 75,  "1 riqueza maior",       true,  41, 60,  "Mágico (médio)", false, true),
                new(76, 100, "1d12x1.000 TO",          false, 61, 100, "Mágico (maior)", false, false),
            ],
            ["20"] =
            [
                new(1,  5,   "—",                      false, 1,  5,   "—",              false, false),
                new(6,  40,  "2d4x1.000 TO",           false, 6,  40,  "Mágico (menor)", false, true),
                new(41, 75,  "1d3 riquezas maiores",    false, 41, 50,  "Mágico (médio)", false, true),
                new(76, 100, "1d3+1 riquezas maiores",  true,  51, 100, "Mágico (maior)", false, true),
            ],
        };
}