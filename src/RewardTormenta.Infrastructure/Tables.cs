using RewardTormenta.Domain.Models;

namespace RewardTormenta.Infrastructure;

/// <summary>
/// Static lookup tables derived from the markdown source files.
/// </summary>
public static class Tables
{
    // ── Equipamento: Armas ───────────────────────────────────────────────────

    public static readonly IReadOnlyList<Weapon> Weapons =
    [
        new() { Name = "Adaga",              MinRoll = 1,   MaxRoll = 3   },
        new() { Name = "Alabarda",           MinRoll = 4,   MaxRoll = 5   },
        new() { Name = "Alfange",            MinRoll = 6,   MaxRoll = 7   },
        new() { Name = "Arco curto",         MinRoll = 8,   MaxRoll = 10  },
        new() { Name = "Arco longo",         MinRoll = 11,  MaxRoll = 13  },
        new() { Name = "Azagaia",            MinRoll = 14,  MaxRoll = 15  },
        new() { Name = "Balas (20)",         MinRoll = 16,  MaxRoll = 16  },
        new() { Name = "Besta leve",         MinRoll = 17,  MaxRoll = 18  },
        new() { Name = "Besta pesada",       MinRoll = 19,  MaxRoll = 20  },
        new() { Name = "Bordão",             MinRoll = 21,  MaxRoll = 23  },
        new() { Name = "Chicote",            MinRoll = 24,  MaxRoll = 24  },
        new() { Name = "Cimitarra",          MinRoll = 25,  MaxRoll = 27  },
        new() { Name = "Clava",              MinRoll = 28,  MaxRoll = 30  },
        new() { Name = "Corrente de espinhos", MinRoll = 31, MaxRoll = 31 },
        new() { Name = "Espada bastarda",    MinRoll = 32,  MaxRoll = 33  },
        new() { Name = "Espada curta",       MinRoll = 34,  MaxRoll = 38  },
        new() { Name = "Espada longa",       MinRoll = 39,  MaxRoll = 43  },
        new() { Name = "Flechas (20)",       MinRoll = 44,  MaxRoll = 46  },
        new() { Name = "Florete",            MinRoll = 47,  MaxRoll = 49  },
        new() { Name = "Foice",              MinRoll = 50,  MaxRoll = 51  },
        new() { Name = "Funda",              MinRoll = 52,  MaxRoll = 53  },
        new() { Name = "Gadanho",            MinRoll = 54,  MaxRoll = 55  },
        new() { Name = "Katana",             MinRoll = 56,  MaxRoll = 56  },
        new() { Name = "Lança",              MinRoll = 57,  MaxRoll = 59  },
        new() { Name = "Lança montada",      MinRoll = 60,  MaxRoll = 60  },
        new() { Name = "Maça",               MinRoll = 61,  MaxRoll = 63  },
        new() { Name = "Machadinha",         MinRoll = 64,  MaxRoll = 66  },
        new() { Name = "Machado anão",       MinRoll = 67,  MaxRoll = 67  },
        new() { Name = "Machado de batalha", MinRoll = 68,  MaxRoll = 70  },
        new() { Name = "Machado de guerra",  MinRoll = 71,  MaxRoll = 73  },
        new() { Name = "Machado táurico",    MinRoll = 74,  MaxRoll = 74  },
        new() { Name = "Mangual",            MinRoll = 75,  MaxRoll = 76  },
        new() { Name = "Marreta",            MinRoll = 77,  MaxRoll = 77  },
        new() { Name = "Martelo de guerra",  MinRoll = 78,  MaxRoll = 80  },
        new() { Name = "Montante",           MinRoll = 81,  MaxRoll = 83  },
        new() { Name = "Mosquete",           MinRoll = 84,  MaxRoll = 84  },
        new() { Name = "Pedras (20)",        MinRoll = 85,  MaxRoll = 85  },
        new() { Name = "Picareta",           MinRoll = 86,  MaxRoll = 88  },
        new() { Name = "Pique",              MinRoll = 89,  MaxRoll = 90  },
        new() { Name = "Pistola",            MinRoll = 91,  MaxRoll = 92  },
        new() { Name = "Rede",               MinRoll = 93,  MaxRoll = 93  },
        new() { Name = "Tacape",             MinRoll = 94,  MaxRoll = 96  },
        new() { Name = "Tridente",           MinRoll = 97,  MaxRoll = 98  },
        new() { Name = "Virotes (20)",       MinRoll = 99,  MaxRoll = 100 },
    ];

    // ── Equipamento: Armaduras ───────────────────────────────────────────────

    public static readonly IReadOnlyList<Armor> Armors =
    [
        new() { Name = "Couro",              MinRoll = 1,   MaxRoll = 5   },
        new() { Name = "Brunea",             MinRoll = 6,   MaxRoll = 10  },
        new() { Name = "Completa",           MinRoll = 11,  MaxRoll = 25  },
        new() { Name = "Cota de malha",      MinRoll = 26,  MaxRoll = 30  },
        new() { Name = "Couraça",            MinRoll = 31,  MaxRoll = 45  },
        new() { Name = "Couro batido",       MinRoll = 46,  MaxRoll = 55  },
        new() { Name = "Escudo leve",        MinRoll = 56,  MaxRoll = 65  },
        new() { Name = "Escudo pesado",      MinRoll = 66,  MaxRoll = 80  },
        new() { Name = "Gibão de peles",     MinRoll = 81,  MaxRoll = 85  },
        new() { Name = "Loriga segmentada",  MinRoll = 86,  MaxRoll = 90  },
        new() { Name = "Meia armadura",      MinRoll = 91,  MaxRoll = 100 },
    ];

    // ── Equipamento: Esotéricos ──────────────────────────────────────────────

    public static readonly IReadOnlyList<EsotericItem> EsotericItems =
    [
        new() { Name = "Bolsa de pó",        MinRoll = 1,   MaxRoll = 10  },
        new() { Name = "Cajado arcano",       MinRoll = 11,  MaxRoll = 25  },
        new() { Name = "Cetro elemental",     MinRoll = 26,  MaxRoll = 35  },
        new() { Name = "Costela de lich",     MinRoll = 36,  MaxRoll = 42  },
        new() { Name = "Dedo de ente",        MinRoll = 43,  MaxRoll = 50  },
        new() { Name = "Luva de ferro",       MinRoll = 51,  MaxRoll = 55  },
        new() { Name = "Medalhão de prata",   MinRoll = 56,  MaxRoll = 65  },
        new() { Name = "Orbe cristalina",     MinRoll = 66,  MaxRoll = 75  },
        new() { Name = "Tomo hermético",      MinRoll = 76,  MaxRoll = 85  },
        new() { Name = "Varinha arcana",      MinRoll = 86,  MaxRoll = 100 },
    ];

    // ── Itens Diversos ───────────────────────────────────────────────────────

    public static readonly IReadOnlyList<MiscItem> MiscItems =
    [
        new() { Name = "Ácido",                     MinRoll = 1,   MaxRoll = 2   },
        new() { Name = "Água benta",                MinRoll = 3,   MaxRoll = 4   },
        new() { Name = "Alaúde élfico",             MinRoll = 5,   MaxRoll = 5   },
        new() { Name = "Algemas",                   MinRoll = 6,   MaxRoll = 6   },
        new() { Name = "Baga-de-fogo",              MinRoll = 7,   MaxRoll = 8   },
        new() { Name = "Bálsamo restaurador",       MinRoll = 9,   MaxRoll = 23  },
        new() { Name = "Bandana",                   MinRoll = 24,  MaxRoll = 24  },
        new() { Name = "Bandoleira de poções",      MinRoll = 25,  MaxRoll = 25  },
        new() { Name = "Bomba",                     MinRoll = 26,  MaxRoll = 30  },
        new() { Name = "Botas reforçadas",          MinRoll = 31,  MaxRoll = 31  },
        new() { Name = "Camisa bufante",            MinRoll = 32,  MaxRoll = 32  },
        new() { Name = "Capa esvoaçante",           MinRoll = 33,  MaxRoll = 33  },
        new() { Name = "Capa pesada",               MinRoll = 34,  MaxRoll = 34  },
        new() { Name = "Casaco longo",              MinRoll = 35,  MaxRoll = 35  },
        new() { Name = "Chapéu arcano",             MinRoll = 36,  MaxRoll = 36  },
        new() { Name = "Coleção de livros",         MinRoll = 37,  MaxRoll = 38  },
        new() { Name = "Cosmético",                 MinRoll = 39,  MaxRoll = 40  },
        new() { Name = "Dente-de-dragão",           MinRoll = 41,  MaxRoll = 42  },
        new() { Name = "Enfeite de elmo",           MinRoll = 43,  MaxRoll = 43  },
        new() { Name = "Elixir do amor",            MinRoll = 44,  MaxRoll = 44  },
        new() { Name = "Equipamento de viagem",     MinRoll = 45,  MaxRoll = 46  },
        new() { Name = "Essência de mana",          MinRoll = 47,  MaxRoll = 56  },
        new() { Name = "Estojo de disfarces",       MinRoll = 57,  MaxRoll = 57  },
        new() { Name = "Farrapos de ermitão",       MinRoll = 58,  MaxRoll = 58  },
        new() { Name = "Flauta mística",            MinRoll = 59,  MaxRoll = 59  },
        new() { Name = "Fogo alquímico",            MinRoll = 60,  MaxRoll = 66  },
        new() { Name = "Gorro de ervas",            MinRoll = 67,  MaxRoll = 67  },
        new() { Name = "Líquen lilás",              MinRoll = 68,  MaxRoll = 69  },
        new() { Name = "Luneta",                    MinRoll = 70,  MaxRoll = 70  },
        new() { Name = "Luva de pelica",            MinRoll = 71,  MaxRoll = 71  },
        new() { Name = "Maleta de medicamentos",    MinRoll = 72,  MaxRoll = 73  },
        new() { Name = "Manopla",                   MinRoll = 74,  MaxRoll = 74  },
        new() { Name = "Manto eclesiástico",        MinRoll = 75,  MaxRoll = 75  },
        new() { Name = "Mochila de aventureiro",    MinRoll = 76,  MaxRoll = 78  },
        new() { Name = "Musgo púrpura",             MinRoll = 79,  MaxRoll = 80  },
        new() { Name = "Organizador de pergaminhos",MinRoll = 81,  MaxRoll = 81  },
        new() { Name = "Ossos de monstro",          MinRoll = 82,  MaxRoll = 83  },
        new() { Name = "Pó de cristal",             MinRoll = 84,  MaxRoll = 85  },
        new() { Name = "Pó de giz",                 MinRoll = 86,  MaxRoll = 87  },
        new() { Name = "Pó do desaparecimento",     MinRoll = 88,  MaxRoll = 88  },
        new() { Name = "Robe místico",              MinRoll = 89,  MaxRoll = 89  },
        new() { Name = "Saco de sal",               MinRoll = 90,  MaxRoll = 91  },
        new() { Name = "Sapatos de camurça",        MinRoll = 92,  MaxRoll = 92  },
        new() { Name = "Seixo de âmbar",            MinRoll = 93,  MaxRoll = 94  },
        new() { Name = "Sela",                      MinRoll = 95,  MaxRoll = 95  },
        new() { Name = "Tabardo",                   MinRoll = 96,  MaxRoll = 96  },
        new() { Name = "Traje da corte",            MinRoll = 97,  MaxRoll = 97  },
        new() { Name = "Terra de cemitério",        MinRoll = 98,  MaxRoll = 99  },
        new() { Name = "Veste de seda",             MinRoll = 100, MaxRoll = 100 },
    ];

    // ── Armas Específicas ────────────────────────────────────────────────────

    public static readonly IReadOnlyList<SpecificWeapon> SpecificWeapons =
    [
        new() { Name = "Azagaia dos relâmpagos", Price = 30_000,  MinRoll = 1,   MaxRoll = 5   },
        new() { Name = "Espada baronial",         Price = 30_000,  MinRoll = 6,   MaxRoll = 15  },
        new() { Name = "Lâmina da luz",           Price = 45_000,  MinRoll = 16,  MaxRoll = 25  },
        new() { Name = "Lança animalesca",        Price = 45_000,  MinRoll = 26,  MaxRoll = 30  },
        new() { Name = "Maça do terror",          Price = 45_000,  MinRoll = 31,  MaxRoll = 35  },
        new() { Name = "Florete fugaz",           Price = 50_000,  MinRoll = 36,  MaxRoll = 40  },
        new() { Name = "Cajado da destruição",    Price = 60_000,  MinRoll = 41,  MaxRoll = 45  },
        new() { Name = "Cajado da vida",          Price = 60_000,  MinRoll = 46,  MaxRoll = 50  },
        new() { Name = "Machado silvestre",       Price = 70_000,  MinRoll = 51,  MaxRoll = 55  },
        new() { Name = "Martelo de Doherimm",     Price = 70_000,  MinRoll = 56,  MaxRoll = 60  },
        new() { Name = "Arco do poder",           Price = 90_000,  MinRoll = 61,  MaxRoll = 67  },
        new() { Name = "Língua do deserto",       Price = 90_000,  MinRoll = 68,  MaxRoll = 72  },
        new() { Name = "Besta explosiva",         Price = 100_000, MinRoll = 73,  MaxRoll = 77  },
        new() { Name = "Punhal sszzaazita",       Price = 100_000, MinRoll = 78,  MaxRoll = 82  },
        new() { Name = "Espada sortuda",          Price = 110_000, MinRoll = 83,  MaxRoll = 87  },
        new() { Name = "Avalanche",               Price = 140_000, MinRoll = 88,  MaxRoll = 92  },
        new() { Name = "Cajado do poder",         Price = 180_000, MinRoll = 93,  MaxRoll = 95  },
        new() { Name = "Vingadora sagrada",       Price = 200_000, MinRoll = 96,  MaxRoll = 100 },
    ];

    // ── Riquezas ─────────────────────────────────────────────────────────────

    public static readonly IReadOnlyList<Wealth> Wealths =
    [
        new() { Tier = TreasureTier.Menor, RollExpression = "4d4",        AverageValue = 10,      MinRoll = 1,  MaxRoll = 25  },
        new() { Tier = TreasureTier.Menor, RollExpression = "1d4x10",     AverageValue = 25,      MinRoll = 26, MaxRoll = 40  },
        new() { Tier = TreasureTier.Menor, RollExpression = "2d4x10",     AverageValue = 50,      MinRoll = 41, MaxRoll = 55  },
        new() { Tier = TreasureTier.Menor, RollExpression = "4d6x10",     AverageValue = 140,     MinRoll = 56, MaxRoll = 70  },
        new() { Tier = TreasureTier.Menor, RollExpression = "1d6x100",    AverageValue = 350,     MinRoll = 71, MaxRoll = 85  },
        new() { Tier = TreasureTier.Menor, RollExpression = "2d6x100",    AverageValue = 700,     MinRoll = 86, MaxRoll = 95  },
        new() { Tier = TreasureTier.Menor, RollExpression = "2d8x100",    AverageValue = 900,     MinRoll = 96, MaxRoll = 99  },
        new() { Tier = TreasureTier.Menor, RollExpression = "4d10x100",   AverageValue = 2_200,   MinRoll = 100,MaxRoll = 100 },

        new() { Tier = TreasureTier.Média, RollExpression = "2d4x10",     AverageValue = 50,      MinRoll = 1,  MaxRoll = 10  },
        new() { Tier = TreasureTier.Média, RollExpression = "4d6x10",     AverageValue = 140,     MinRoll = 11, MaxRoll = 30  },
        new() { Tier = TreasureTier.Média, RollExpression = "1d6x100",    AverageValue = 350,     MinRoll = 31, MaxRoll = 50  },
        new() { Tier = TreasureTier.Média, RollExpression = "2d6x100",    AverageValue = 700,     MinRoll = 51, MaxRoll = 65  },
        new() { Tier = TreasureTier.Média, RollExpression = "2d8x100",    AverageValue = 900,     MinRoll = 66, MaxRoll = 80  },
        new() { Tier = TreasureTier.Média, RollExpression = "4d10x100",   AverageValue = 2_200,   MinRoll = 81, MaxRoll = 90  },
        new() { Tier = TreasureTier.Média, RollExpression = "6d12x100",   AverageValue = 3_900,   MinRoll = 91, MaxRoll = 95  },
        new() { Tier = TreasureTier.Média, RollExpression = "2d10x1.000", AverageValue = 11_000,  MinRoll = 96, MaxRoll = 99  },
        new() { Tier = TreasureTier.Média, RollExpression = "6d8x1.000",  AverageValue = 27_000,  MinRoll = 100,MaxRoll = 100 },

        new() { Tier = TreasureTier.Maior, RollExpression = "1d6x100",       AverageValue = 350,     MinRoll = 1,  MaxRoll = 5   },
        new() { Tier = TreasureTier.Maior, RollExpression = "2d6x100",       AverageValue = 700,     MinRoll = 6,  MaxRoll = 15  },
        new() { Tier = TreasureTier.Maior, RollExpression = "2d8x100",       AverageValue = 900,     MinRoll = 16, MaxRoll = 25  },
        new() { Tier = TreasureTier.Maior, RollExpression = "4d10x100",      AverageValue = 2_200,   MinRoll = 26, MaxRoll = 40  },
        new() { Tier = TreasureTier.Maior, RollExpression = "6d12x100",      AverageValue = 3_900,   MinRoll = 41, MaxRoll = 60  },
        new() { Tier = TreasureTier.Maior, RollExpression = "2d10x1.000",    AverageValue = 11_000,  MinRoll = 61, MaxRoll = 75  },
        new() { Tier = TreasureTier.Maior, RollExpression = "6d8x1.000",     AverageValue = 27_000,  MinRoll = 76, MaxRoll = 85  },
        new() { Tier = TreasureTier.Maior, RollExpression = "1d10x10.000",   AverageValue = 55_000,  MinRoll = 86, MaxRoll = 95  },
        new() { Tier = TreasureTier.Maior, RollExpression = "4d12x10.000",   AverageValue = 260_000, MinRoll = 96, MaxRoll = 100 },
    ];
}