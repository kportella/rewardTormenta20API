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

    // ── Armaduras Específicas ────────────────────────────────────────────────

    public static readonly IReadOnlyList<SpecificArmor> SpecificArmors =
    [
        new() { Name = "Cota élfica",          Price = 30_000,  MinRoll = 1,   MaxRoll = 10  },
        new() { Name = "Couro de monstro",     Price = 36_000,  MinRoll = 11,  MaxRoll = 20  },
        new() { Name = "Escudo do conjurador", Price = 45_000,  MinRoll = 21,  MaxRoll = 25  },
        new() { Name = "Loriga do centurião",  Price = 45_000,  MinRoll = 26,  MaxRoll = 32  },
        new() { Name = "Manto da noite",       Price = 45_000,  MinRoll = 33,  MaxRoll = 42  },
        new() { Name = "Couraça do comando",   Price = 45_000,  MinRoll = 43,  MaxRoll = 49  },
        new() { Name = "Baluarte anão",        Price = 50_000,  MinRoll = 50,  MaxRoll = 59  },
        new() { Name = "Escudo espinhoso",     Price = 50_000,  MinRoll = 60,  MaxRoll = 66  },
        new() { Name = "Escudo do leão",       Price = 50_000,  MinRoll = 67,  MaxRoll = 76  },
        new() { Name = "Carapaça demoníaca",   Price = 63_000,  MinRoll = 77,  MaxRoll = 83  },
        new() { Name = "Escudo do eclipse",    Price = 70_000,  MinRoll = 84,  MaxRoll = 88  },
        new() { Name = "Escudo de Azgher",     Price = 140_000, MinRoll = 89,  MaxRoll = 93  },
        new() { Name = "Armadura da luz",      Price = 150_000, MinRoll = 94,  MaxRoll = 100 },
    ];

    // ── Poções ───────────────────────────────────────────────────────────────

    public static readonly IReadOnlyList<Potion> Potions =
    [
        new() { Name = "Abençoar Alimentos (óleo)",                                 Price = 30,    MinRoll = 1,   MaxRoll = 1   },
        new() { Name = "Área Escorregadia (granada)",                               Price = 30,    MinRoll = 2,   MaxRoll = 3   },
        new() { Name = "Arma Mágica (óleo)",                                        Price = 30,    MinRoll = 4,   MaxRoll = 6   },
        new() { Name = "Compreensão",                                               Price = 30,    MinRoll = 7,   MaxRoll = 7   },
        new() { Name = "Curar Ferimentos (2d8+2 PV)",                               Price = 30,    MinRoll = 8,   MaxRoll = 15  },
        new() { Name = "Disfarce Ilusório",                                         Price = 30,    MinRoll = 16,  MaxRoll = 18  },
        new() { Name = "Escuridão (óleo)",                                          Price = 30,    MinRoll = 19,  MaxRoll = 20  },
        new() { Name = "Luz (óleo)",                                                Price = 30,    MinRoll = 21,  MaxRoll = 22  },
        new() { Name = "Névoa (granada)",                                           Price = 30,    MinRoll = 23,  MaxRoll = 24  },
        new() { Name = "Primor Atlético",                                           Price = 30,    MinRoll = 25,  MaxRoll = 26  },
        new() { Name = "Proteção Divina",                                           Price = 30,    MinRoll = 27,  MaxRoll = 28  },
        new() { Name = "Resistência à Energia",                                     Price = 30,    MinRoll = 29,  MaxRoll = 30  },
        new() { Name = "Sono",                                                      Price = 30,    MinRoll = 31,  MaxRoll = 32  },
        new() { Name = "Suporte Ambiental",                                         Price = 30,    MinRoll = 33,  MaxRoll = 33  },
        new() { Name = "Tranca Arcana (óleo)",                                      Price = 30,    MinRoll = 34,  MaxRoll = 34  },
        new() { Name = "Visão Mística",                                             Price = 30,    MinRoll = 35,  MaxRoll = 35  },
        new() { Name = "Vitalidade Fantasma",                                       Price = 30,    MinRoll = 36,  MaxRoll = 36  },
        new() { Name = "Escudo da Fé (aprimoramento para duração cena)",            Price = 120,   MinRoll = 37,  MaxRoll = 38  },
        new() { Name = "Alterar Tamanho",                                           Price = 270,   MinRoll = 39,  MaxRoll = 40  },
        new() { Name = "Aparência Perfeita",                                        Price = 270,   MinRoll = 41,  MaxRoll = 42  },
        new() { Name = "Armamento da Natureza (óleo)",                              Price = 270,   MinRoll = 43,  MaxRoll = 43  },
        new() { Name = "Bala de Fogo (granada)",                                    Price = 270,   MinRoll = 44,  MaxRoll = 49  },
        new() { Name = "Camuflagem Ilusória",                                       Price = 270,   MinRoll = 50,  MaxRoll = 51  },
        new() { Name = "Concentração de Combate (aprimoramento para duração cena)", Price = 270,   MinRoll = 52,  MaxRoll = 53  },
        new() { Name = "Curar Ferimentos (4d8+4 PV)",                               Price = 270,   MinRoll = 54,  MaxRoll = 62  },
        new() { Name = "Forma Divina",                                              Price = 270,   MinRoll = 63,  MaxRoll = 66  },
        new() { Name = "Mente Divina",                                              Price = 270,   MinRoll = 67,  MaxRoll = 68  },
        new() { Name = "Metamorfose",                                               Price = 270,   MinRoll = 69,  MaxRoll = 70  },
        new() { Name = "Purificação",                                               Price = 270,   MinRoll = 71,  MaxRoll = 75  },
        new() { Name = "Velocidade",                                                Price = 270,   MinRoll = 76,  MaxRoll = 77  },
        new() { Name = "Vestimenta da Fé (óleo)",                                   Price = 270,   MinRoll = 78,  MaxRoll = 79  },
        new() { Name = "Voz Divina",                                                Price = 270,   MinRoll = 80,  MaxRoll = 80  },
        new() { Name = "Arma Mágica (óleo; aprimoramento para bônus +3)",           Price = 750,   MinRoll = 81,  MaxRoll = 82  },
        new() { Name = "Curar Ferimentos (7d8+7 PV)",                               Price = 1_080, MinRoll = 83,  MaxRoll = 88  },
        new() { Name = "Físico Divino (aprimoramento para três atributos)",         Price = 1_080, MinRoll = 89,  MaxRoll = 89  },
        new() { Name = "Invisibilidade (aprimoramento para duração cena)",          Price = 1_080, MinRoll = 90,  MaxRoll = 92  },
        new() { Name = "Bola de Fogo (granada; aprimoramento para 10d6 de dano)",   Price = 1_470, MinRoll = 93,  MaxRoll = 96  },
        new() { Name = "Curar Ferimentos (11d8+11 PV)",                             Price = 3_000, MinRoll = 97,  MaxRoll = 100 },
    ];

    // ── Acessórios (Tabelas 8-13, 8-14, 8-15) ───────────────────────────────

    public static readonly IReadOnlyList<Accessory> Accessories =
    [
        // Tabela 8-13 — Menores
        new() { Tier = MagicItemTier.Menor, Name = "Anel do sustento",              Price = 3_000,   MinRoll = 1,   MaxRoll = 2   },
        new() { Tier = MagicItemTier.Menor, Name = "Bainha mágica",                  Price = 3_000,   MinRoll = 3,   MaxRoll = 7   },
        new() { Tier = MagicItemTier.Menor, Name = "Corda da escalada",              Price = 3_000,   MinRoll = 8,   MaxRoll = 12  },
        new() { Tier = MagicItemTier.Menor, Name = "Ferraduras da velocidade",       Price = 3_000,   MinRoll = 13,  MaxRoll = 14  },
        new() { Tier = MagicItemTier.Menor, Name = "Garrafa da fumaça eterna",       Price = 3_000,   MinRoll = 15,  MaxRoll = 19  },
        new() { Tier = MagicItemTier.Menor, Name = "Gema da luminosidade",           Price = 3_000,   MinRoll = 20,  MaxRoll = 24  },
        new() { Tier = MagicItemTier.Menor, Name = "Manto élfico",                   Price = 3_000,   MinRoll = 25,  MaxRoll = 29  },
        new() { Tier = MagicItemTier.Menor, Name = "Mochila de carga",               Price = 3_000,   MinRoll = 30,  MaxRoll = 34  },
        new() { Tier = MagicItemTier.Menor, Name = "Brincos da sagacidade",          Price = 4_500,   MinRoll = 35,  MaxRoll = 40  },
        new() { Tier = MagicItemTier.Menor, Name = "Luvas da delicadeza",            Price = 4_500,   MinRoll = 41,  MaxRoll = 46  },
        new() { Tier = MagicItemTier.Menor, Name = "Manoplas da força do ogro",      Price = 4_500,   MinRoll = 47,  MaxRoll = 52  },
        new() { Tier = MagicItemTier.Menor, Name = "Manta da resistência",           Price = 4_500,   MinRoll = 53,  MaxRoll = 59  },
        new() { Tier = MagicItemTier.Menor, Name = "Manto do fascínio",              Price = 4_500,   MinRoll = 60,  MaxRoll = 65  },
        new() { Tier = MagicItemTier.Menor, Name = "Pingente da sensatez",           Price = 4_500,   MinRoll = 66,  MaxRoll = 71  },
        new() { Tier = MagicItemTier.Menor, Name = "Torque do vigor",                Price = 4_500,   MinRoll = 72,  MaxRoll = 77  },
        new() { Tier = MagicItemTier.Menor, Name = "Chapéu do disfarce",             Price = 6_000,   MinRoll = 78,  MaxRoll = 82  },
        new() { Tier = MagicItemTier.Menor, Name = "Flauta fantasma",                Price = 6_000,   MinRoll = 83,  MaxRoll = 84  },
        new() { Tier = MagicItemTier.Menor, Name = "Lanterna da revelação",          Price = 6_000,   MinRoll = 85,  MaxRoll = 89  },
        new() { Tier = MagicItemTier.Menor, Name = "Anel da proteção",               Price = 9_000,   MinRoll = 90,  MaxRoll = 96  },
        new() { Tier = MagicItemTier.Menor, Name = "Anel do escudo mental",          Price = 9_000,   MinRoll = 97,  MaxRoll = 98  },
        new() { Tier = MagicItemTier.Menor, Name = "Pingente da saúde",              Price = 9_000,   MinRoll = 99,  MaxRoll = 100 },

        // Tabela 8-14 — Médios
        new() { Tier = MagicItemTier.Médio, Name = "Anel de telecinese",             Price = 10_500,  MinRoll = 1,   MaxRoll = 4   },
        new() { Tier = MagicItemTier.Médio, Name = "Bola de cristal",                Price = 10_500,  MinRoll = 5,   MaxRoll = 8   },
        new() { Tier = MagicItemTier.Médio, Name = "Caveira maldita",                Price = 10_500,  MinRoll = 9,   MaxRoll = 10  },
        new() { Tier = MagicItemTier.Médio, Name = "Botas aladas",                   Price = 15_000,  MinRoll = 11,  MaxRoll = 14  },
        new() { Tier = MagicItemTier.Médio, Name = "Braceletes de bronze",           Price = 16_500,  MinRoll = 15,  MaxRoll = 18  },
        new() { Tier = MagicItemTier.Médio, Name = "Anel da energia",                Price = 21_000,  MinRoll = 19,  MaxRoll = 24  },
        new() { Tier = MagicItemTier.Médio, Name = "Anel da vitalidade",             Price = 21_000,  MinRoll = 25,  MaxRoll = 30  },
        new() { Tier = MagicItemTier.Médio, Name = "Anel de invisibilidade",         Price = 21_000,  MinRoll = 31,  MaxRoll = 34  },
        new() { Tier = MagicItemTier.Médio, Name = "Braçadeiras do arqueiro",        Price = 21_000,  MinRoll = 35,  MaxRoll = 38  },
        new() { Tier = MagicItemTier.Médio, Name = "Brincos de Marah",               Price = 21_000,  MinRoll = 39,  MaxRoll = 42  },
        new() { Tier = MagicItemTier.Médio, Name = "Faixas do pugilista",            Price = 21_000,  MinRoll = 43,  MaxRoll = 46  },
        new() { Tier = MagicItemTier.Médio, Name = "Manto da aranha",                Price = 21_000,  MinRoll = 47,  MaxRoll = 50  },
        new() { Tier = MagicItemTier.Médio, Name = "Vassoura voadora",               Price = 21_000,  MinRoll = 51,  MaxRoll = 54  },
        new() { Tier = MagicItemTier.Médio, Name = "Símbolo abençoado",              Price = 21_000,  MinRoll = 55,  MaxRoll = 58  },
        new() { Tier = MagicItemTier.Médio, Name = "Amuleto da robustez",            Price = 25_500,  MinRoll = 59,  MaxRoll = 64  },
        new() { Tier = MagicItemTier.Médio, Name = "Botas velozes",                  Price = 25_500,  MinRoll = 65,  MaxRoll = 68  },
        new() { Tier = MagicItemTier.Médio, Name = "Cinta da força do gigante",      Price = 25_500,  MinRoll = 69,  MaxRoll = 74  },
        new() { Tier = MagicItemTier.Médio, Name = "Coroa majestosa",                Price = 25_500,  MinRoll = 75,  MaxRoll = 80  },
        new() { Tier = MagicItemTier.Médio, Name = "Estola da serenidade",           Price = 25_500,  MinRoll = 81,  MaxRoll = 86  },
        new() { Tier = MagicItemTier.Médio, Name = "Manto do morcego",               Price = 25_500,  MinRoll = 87,  MaxRoll = 88  },
        new() { Tier = MagicItemTier.Médio, Name = "Pulseiras da celeridade",        Price = 25_500,  MinRoll = 89,  MaxRoll = 94  },
        new() { Tier = MagicItemTier.Médio, Name = "Tiara da sapiência",             Price = 25_500,  MinRoll = 95,  MaxRoll = 100 },

        // Tabela 8-15 — Maiores
        new() { Tier = MagicItemTier.Maior, Name = "Elmo do teletransporte",         Price = 30_000,  MinRoll = 1,   MaxRoll = 2   },
        new() { Tier = MagicItemTier.Maior, Name = "Gema da telepatia",              Price = 30_000,  MinRoll = 3,   MaxRoll = 4   },
        new() { Tier = MagicItemTier.Maior, Name = "Gema elemental",                 Price = 30_000,  MinRoll = 5,   MaxRoll = 9   },
        new() { Tier = MagicItemTier.Maior, Name = "Manual da saúde corporal",       Price = 30_000,  MinRoll = 10,  MaxRoll = 15  },
        new() { Tier = MagicItemTier.Maior, Name = "Manual do bom exercício",        Price = 30_000,  MinRoll = 16,  MaxRoll = 21  },
        new() { Tier = MagicItemTier.Maior, Name = "Manual dos movimentos precisos", Price = 30_000,  MinRoll = 22,  MaxRoll = 27  },
        new() { Tier = MagicItemTier.Maior, Name = "Medalhão de Lena",               Price = 30_000,  MinRoll = 28,  MaxRoll = 34  },
        new() { Tier = MagicItemTier.Maior, Name = "Tomo da compreensão",            Price = 30_000,  MinRoll = 35,  MaxRoll = 40  },
        new() { Tier = MagicItemTier.Maior, Name = "Tomo da liderança e influência", Price = 30_000,  MinRoll = 41,  MaxRoll = 46  },
        new() { Tier = MagicItemTier.Maior, Name = "Tomo dos grandes pensamentos",   Price = 30_000,  MinRoll = 47,  MaxRoll = 52  },
        new() { Tier = MagicItemTier.Maior, Name = "Anel refletor",                  Price = 51_000,  MinRoll = 53,  MaxRoll = 57  },
        new() { Tier = MagicItemTier.Maior, Name = "Cinto do campeão",               Price = 51_000,  MinRoll = 58,  MaxRoll = 60  },
        new() { Tier = MagicItemTier.Maior, Name = "Colar guardião",                 Price = 51_000,  MinRoll = 61,  MaxRoll = 67  },
        new() { Tier = MagicItemTier.Maior, Name = "Estatueta animista",             Price = 51_000,  MinRoll = 68,  MaxRoll = 72  },
        new() { Tier = MagicItemTier.Maior, Name = "Anel da liberdade",              Price = 60_000,  MinRoll = 73,  MaxRoll = 77  },
        new() { Tier = MagicItemTier.Maior, Name = "Tapete voador",                  Price = 60_000,  MinRoll = 78,  MaxRoll = 82  },
        new() { Tier = MagicItemTier.Maior, Name = "Braceletes de ouro",             Price = 64_500,  MinRoll = 83,  MaxRoll = 87  },
        new() { Tier = MagicItemTier.Maior, Name = "Espelho da oposição",            Price = 75_000,  MinRoll = 88,  MaxRoll = 89  },
        new() { Tier = MagicItemTier.Maior, Name = "Robe do arquimago",              Price = 90_000,  MinRoll = 90,  MaxRoll = 94  },
        new() { Tier = MagicItemTier.Maior, Name = "Orbe das tempestades",           Price = 97_500,  MinRoll = 95,  MaxRoll = 96  },
        new() { Tier = MagicItemTier.Maior, Name = "Anel da regeneração",            Price = 150_000, MinRoll = 97,  MaxRoll = 98  },
        new() { Tier = MagicItemTier.Maior, Name = "Espelho do aprisionamento",      Price = 150_000, MinRoll = 99,  MaxRoll = 100 },
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