namespace RewardTormenta.Domain.Models;

public enum WeaponEnchantment
{
    Ameacadora,
    Anticriatura,
    Arremesso,
    Assassina,
    Cacadora,
    Congelante,
    Conjuradora,
    Corrosiva,
    Dancarina,
    Defensora,
    Destruidora,
    Dilacerante,
    Drenante,
    Eletrica,
    Energetica,        // Conta como dois encantos
    Excruciante,
    Flamejante,
    Formidavel,
    Lancinante,        // Conta como dois encantos
    Magnifica,         // Conta como dois encantos
    Piedosa,
    Profana,
    Sagrada,
    Sanguinaria,
    Trovejante,
    Tumular,
    Veloz,
    Venenosa,
    ArmaEspecifica
}

public enum SpecialMaterial
{
    AcoRubi = 1,
    Adamante = 2,
    GeloEterno = 3,
    MadeiraTollon = 4,
    MateriaVermelha = 5,
    Mitral = 6
}

public enum WeaponImprovement
{
    Atroz,              // Conta como duas melhorias
    BanhadaAOuro,
    Certeira,
    CravejaDeGemas,
    Cruel,
    Discreta,
    Equilibrada,
    Harmonizada,
    InjecaoAlquimica,
    Macabra,
    Macica,
    MaterialEspecial,
    MiraTelescoópica,
    Precisa,
    Pungente            // Conta como duas melhorias
}

public enum ArmorImprovement
{
    Ajustada,
    BanhadaAOuro,
    CravejaDeGemas,
    Delicada,
    Discreta,
    Espinhos,
    Macabra,
    MaterialEspecial,
    Polida,
    Reforcada,
    Selada,
    SobMedida           // Conta como duas melhorias
}

public enum EsotericImprovement
{
    BanhadoAOuro,
    Canalizador,
    CravejaDeGemas,
    Discreto,
    Energetico,
    Harmonizado,
    Macabro,
    MaterialEspecial,
    Vigilante
}

public enum TreasureTier
{
    Menor,
    Media,
    Maior
}

public enum MagicItemTier
{
    Menor,
    Medio,
    Maior
}

public enum ArmorEnchantment
{
    Abascanto,
    Abencoado,
    Acrobatico,
    Alado,
    Animado,           // Apenas escudos. Para armaduras, role novamente.
    Assustador,
    Caustica,
    Defensor,
    Escorregadio,
    Esmagador,         // Apenas escudos. Para armaduras, role novamente.
    Fantasmagorico,
    Fortificado,
    Gelido,
    Guardiao,          // Conta como dois encantos. Para itens menores, role novamente.
    Hipnotico,
    Ilusorio,
    Incandescente,
    Invulneravel,
    Opaco,
    Protetor,
    Refletor,
    Relampejante,
    Reluzente,
    Sombrio,
    Zeloso,
    ItemEspecifico
}