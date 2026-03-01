using RewardTormenta.Application;
using RewardTormenta.Domain.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<TreasureRoller>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/treasure", (string challengeRating, TreasureRoller roller) =>
{
    try
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

            if (itemRow.ItemDescription == "Diverso")
            {
                int roll = roller.RollD100();
                miscItemName = roller.RollMiscItem(roll)?.Name;
                miscRoll = roll;
            }
            else if (itemRow.ItemDescription == "Equipamento")
            {
                equipmentChoices = roller.RollEquipment();
            }
            else if (itemRow.ItemDescription.StartsWith("Mágico"))
            {
                equipmentChoices = roller.RollMagicItem();
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
                Description      = itemRow.ItemDescription,
                HasRollBonus     = itemRow.ItemHasRollBonus,
                HasDualRoll      = itemRow.ItemHasDualRoll,
                Roll             = itemRoll,
                Item             = miscItemName,
                MiscRoll         = miscRoll,
                Potions          = potions,
                EquipmentChoices = equipmentChoices
            };
        }

        var result = new TreasureResult
        {
            ChallengeRating = ParseChallengeRating(challengeRating),
            Money = money,
            Item  = item
        };

        return Results.Ok(result);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
})
.WithName("GenerateTreasure")
.WithOpenApi();

app.MapGet("/roll/accessory", (string tier, TreasureRoller roller) =>
{
    if (!Enum.TryParse<MagicItemTier>(tier, ignoreCase: true, out var magicTier))
        return Results.BadRequest(new { error = $"Unknown tier '{tier}'. Use Menor, Médio, or Maior." });

    int roll = roller.RollD100();
    var accessory = roller.RollAccessory(magicTier, roll);

    if (accessory is null)
        return Results.Problem("No accessory matched the roll — check table data.");

    return Results.Ok(new
    {
        tier     = accessory.Tier.ToString(),
        name     = accessory.Name,
        price    = accessory.Price,
        roll
    });
})
.WithName("RollAccessory")
.WithOpenApi();

app.Run();

static int ParseChallengeRating(string cr) => cr switch
{
    "1/4" => 0,
    "1/2" => 0,
    _ => int.TryParse(cr, out var value) ? value : 0
};
