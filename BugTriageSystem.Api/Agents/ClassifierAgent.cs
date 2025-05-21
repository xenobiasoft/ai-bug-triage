using BugTriageSystem.Api.Models;
using BugTriageSystem.Api.Services;

namespace BugTriageSystem.Api.Agents;

public class ClassifierAgent(IAzureOpenAiService openAiService)
{
    private const string SystemPrompt = "You are a senior triage engineer. Read the bug report and return a JSON object with category and severity.";

    public async Task<ClassificationResult> Classify(string bugReport)
    {
        return await openAiService.GetCompletionAsync<ClassificationResult>(bugReport, SystemPrompt);
    }
}