using System.Text.Json.Serialization;
using RewardTormenta.Application;
using RewardTormenta.Domain.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<TreasureRoller>();
builder.Services.ConfigureHttpJsonOptions(o =>
    o.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/treasure", (string[] challengeRating, TreasureRoller roller) =>
{
    if (challengeRating.Length == 0)
        return Results.BadRequest(new { error = "At least one challengeRating is required." });

    try
    {
        var results = challengeRating
            .Select(cr => BuildTreasureResult(cr, roller))
            .ToList();
        return Results.Ok(results);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
})
.WithName("GenerateTreasure")
.WithOpenApi();

app.MapGet("/roll/magicItem", (string type, string tier, TreasureRoller roller) =>
{
    if (!Enum.TryParse<MagicItemTier>(tier, ignoreCase: true, out var magicTier) || int.TryParse(tier, out _))
        return Results.BadRequest(new { error = $"Unknown tier '{tier}'. Use Menor, Medio, or Maior." });

    var validTypes = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        { "arma", "armadura/escudo", "acessorio menor", "acessorio medio", "acessorio maior" };

    if (!validTypes.Contains(type))
        return Results.BadRequest(new { error = $"Unknown type '{type}'. Valid values: arma, armadura/escudo, acessorio menor, acessorio medio, acessorio maior." });

    var resolved = roller.RollMagicItemByType(type, magicTier);
    return Results.Ok(resolved);
})
.WithName("RollMagicItem")
.WithOpenApi();

app.MapGet("/roll/equipment", (string type, int improvements, TreasureRoller roller) =>
{
    if (improvements is < 1 or > 4)
        return Results.BadRequest(new { error = "improvements must be between 1 and 4." });

    var validTypes = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        { "arma", "armadura", "escudo", "esoterico" };

    if (!validTypes.Contains(type))
        return Results.BadRequest(new { error = $"Unknown type '{type}'. Valid values: arma, armadura, escudo, esoterico." });

    var item = roller.RollSuperiorItemByType(type, improvements);
    return Results.Ok(item);
})
.WithName("RollEquipment")
.WithOpenApi();

app.Run();

static TreasureResult BuildTreasureResult(string challengeRating, TreasureRoller roller)
{
    var (moneyRow, itemRow, moneyRoll, itemRoll) = roller.RollTreasure(challengeRating);

    MoneyResult? money = null;
    if (moneyRow is not null)
    {
        if (moneyRow.MoneyDescription != "—")
        {
            var (amount, currency) = roller.RollMoneyAmount(moneyRow.MoneyDescription);
            money = new MoneyResult { Amount = amount, Currency = currency, Roll = moneyRoll };
        }
        else
        {
            money = new MoneyResult { Amount = 0, Currency = "—", Roll = moneyRoll };
        }
    }

    ItemResult? item = null;
    if (itemRow is not null)
    {
        string? miscItemName = null;
        int? miscRoll = null;
        List<PotionResult>? potions = null;
        EquipmentChoiceResult? equipmentChoices = null;
        SuperiorItem? resolvedSuperiorItem = null;
        ResolvedMagicItem? resolvedMagicItem = null;

        if (itemRow.ItemDescription == "Diverso")
        {
            int roll = roller.RollD100();
            miscItemName = roller.RollMiscItem(roll)?.Name;
            miscRoll = roll;
        }
        else if (itemRow.ItemDescription == "Equipamento")
        {
            equipmentChoices = roller.RollEquipment(itemRow.ItemHasDualRoll);
        }
        else if (itemRow.ItemDescription.StartsWith("Superior"))
        {
            if (!itemRow.ItemHasDualRoll)
            {
                int slots = ParseImprovementSlots(itemRow.ItemDescription);
                resolvedSuperiorItem = roller.RollSuperiorItem(slots);
            }
            else
            {
                equipmentChoices = roller.RollEquipment(dualRoll: true);
            }
        }
        else if (itemRow.ItemDescription.StartsWith("Mágico"))
        {
            if (!itemRow.ItemHasDualRoll)
            {
                var magicTier = ParseMagicItemTier(itemRow.ItemDescription);
                resolvedMagicItem = roller.RollMagicItemFull(magicTier);
            }
            else
            {
                equipmentChoices = roller.RollMagicItem(dualRoll: true);
            }
        }
        else if (itemRow.ItemDescription.Contains("poção") || itemRow.ItemDescription.Contains("poções"))
        {
            potions = roller.RollPotions(itemRow.ItemDescription)
                .Select(t => new PotionResult
                {
                    Name  = t.Potion.Name,
                    Price = t.Potion.Price,
                    Roll  = t.Roll
                })
                .ToList();
        }

        item = new ItemResult
        {
            Description          = itemRow.ItemDescription,
            HasRollBonus         = itemRow.ItemHasRollBonus,
            HasDualRoll          = itemRow.ItemHasDualRoll,
            Roll                 = itemRoll,
            Item                 = miscItemName,
            MiscRoll             = miscRoll,
            Potions              = potions,
            EquipmentChoices     = equipmentChoices,
            ResolvedSuperiorItem = resolvedSuperiorItem,
            ResolvedMagicItem    = resolvedMagicItem
        };
    }

    return new TreasureResult
    {
        ChallengeRating = ParseChallengeRating(challengeRating),
        Money = money,
        Item  = item
    };
}

static MagicItemTier ParseMagicItemTier(string description)
{
    // "Mágico (menor)" → Menor, "Mágico (médio)" → Médio, "Mágico (maior)" → Maior
    if (description.Contains("menor")) return MagicItemTier.Menor;
    if (description.Contains("medio")) return MagicItemTier.Medio;
    return MagicItemTier.Maior;
}

static int ParseImprovementSlots(string description)
{
    // Input: "Superior (2 melhorias)" or "Superior (1 melhoria)"
    int open  = description.IndexOf('(') + 1;
    int space = description.IndexOf(' ', open);
    return int.Parse(description[open..space]);
}

static int ParseChallengeRating(string cr) => cr switch
{
    "1/4" => 0,
    "1/2" => 0,
    _ => int.TryParse(cr, out var value) ? value : 0
};
