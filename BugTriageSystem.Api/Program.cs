using BugTriageSystem.Api.Agents;
using BugTriageSystem.Api.Models;
using BugTriageSystem.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();

// Add services
builder.Services.AddHttpClient();
builder.Services.AddSingleton<IAzureOpenAiService, AzureOpenAiService>();
builder.Services.AddSingleton<ClassifierAgent>();
builder.Services.AddSingleton<FixRecommenderAgent>();
builder.Services.AddSingleton<ReviewerAgent>();
builder.Services.AddSingleton<BugTriageOrchestrator>();

// Add logging
builder.Services.AddLogging();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapPost("/api/bug-triage", async (
    BugReport bugReport,
    BugTriageOrchestrator orchestrator) =>
{
    var result = await orchestrator.ProcessBugReport(bugReport.Description);
    return Results.Ok(result);
});

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
