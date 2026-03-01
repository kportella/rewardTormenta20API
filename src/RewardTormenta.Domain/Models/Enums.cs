namespace RewardTormenta.Domain.Models;

public enum WeaponEnchantment
{
    Ameaçadora,
    Anticriatura,
    Arremesso,
    Assassina,
    Caçadora,
    Congelante,
    Conjuradora,
    Corrosiva,
    Dançarina,
    Defensora,
    Destruidora,
    Dilacerante,
    Drenante,
    Elétrica,
    Energética,        // Conta como dois encantos
    Excruciante,
    Flamejante,
    Formidável,
    Lancinante,        // Conta como dois encantos
    Magnífica,         // Conta como dois encantos
    Piedosa,
    Profana,
    Sagrada,
    Sanguinária,
    Trovejante,
    Tumular,
    Veloz,
    Venenosa,
    ArmaEspecífica
}

public enum SpecialMaterial
{
    AçoRubi = 1,
    Adamante = 2,
    GeloEterno = 3,
    MadeiraTollon = 4,
    MatériaVermelha = 5,
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
    InjeçãoAlquímica,
    Macabra,
    Maciça,
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
    Reforçada,
    Selada,
    SobMedida           // Conta como duas melhorias
}

public enum EsotericImprovement
{
    BanhadoAOuro,
    Canalizador,
    CravejaDeGemas,
    Discreto,
    Energético,
    Harmonizado,
    Macabro,
    MaterialEspecial,
    Vigilante
}

public enum TreasureTier
{
    Menor,
    Média,
    Maior
}

public enum MagicItemTier
{
    Menor,
    Médio,
    Maior
}