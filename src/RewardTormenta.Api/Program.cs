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

app.MapGet("/treasure/{challengeRating}", (string challengeRating, TreasureRoller roller) =>
{
    try
    {
        var (moneyRow, itemRow, moneyRoll, itemRoll) = roller.RollTreasure(challengeRating);

        MoneyResult? money = null;
        if (moneyRow is not null)
        {
            var (amount, currency) = roller.RollMoneyAmount(moneyRow.MoneyDescription);
            money = new MoneyResult { Amount = amount, Currency = currency, Roll = moneyRoll };
        }

        var result = new TreasureResult
        {
            ChallengeRating = ParseChallengeRating(challengeRating),
            Money = money,
            Item = itemRow is not null ? new ItemResult
            {
                Description  = itemRow.ItemDescription,
                HasRollBonus = itemRow.ItemHasRollBonus,
                HasDualRoll  = itemRow.ItemHasDualRoll,
                Roll         = itemRoll
            } : null
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
