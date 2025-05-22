using BugTriageSystem.Api.Models;
using BugTriageSystem.Api.Services;

namespace BugTriageSystem.Api.Agents;

public class ClassifierAgent(IAzureOpenAiService openAiService)
{
    private const string SystemPrompt = "You are a senior triage engineer. Read the bug report and classify the bug. Return a JSON object with classification, justification, and confidence-score between 0 and 1.";

    public async Task<ClassificationResult> Classify(string bugReport)
    {
        return await openAiService.GetCompletionAsync<ClassificationResult>(bugReport, SystemPrompt);
    }
}