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

            if (itemRow.ItemDescription == "Diverso")
            {
                int roll = roller.RollD100();
                miscItemName = roller.RollMiscItem(roll)?.Name;
                miscRoll = roll;
            }
            else if (itemRow.ItemDescription == "Equipamento")
            {
                var (name, equipRoll) = roller.RollEquipment();
                miscItemName = name;
                miscRoll = equipRoll;
            }

            item = new ItemResult
            {
                Description  = itemRow.ItemDescription,
                HasRollBonus = itemRow.ItemHasRollBonus,
                HasDualRoll  = itemRow.ItemHasDualRoll,
                Roll         = itemRoll,
                Item         = miscItemName,
                MiscRoll     = miscRoll
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

app.Run();

static int ParseChallengeRating(string cr) => cr switch
{
    "1/4" => 0,
    "1/2" => 0,
    _ => int.TryParse(cr, out var value) ? value : 0
};
