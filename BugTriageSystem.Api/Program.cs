using BugTriageSystem.Api.Agents;
using BugTriageSystem.Api.Models;
using BugTriageSystem.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

// Add services
builder.Services.AddHttpClient();
builder.Services.AddSingleton<IAzureOpenAiService, AzureOpenAiService>();
builder.Services.AddSingleton<ClassifierAgent>();
builder.Services.AddSingleton<FixRecommenderAgent>();
builder.Services.AddSingleton<ReviewerAgent>();
builder.Services.AddSingleton<BugTriageOrchestrator>();

builder.Services.AddLogging();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/api/bug-triage", async (
    BugReport bugReport,
    BugTriageOrchestrator orchestrator) =>
{
    var result = await orchestrator.ProcessBugReport(bugReport.Description);
    return Results.Ok(result);
});

app.Run();
