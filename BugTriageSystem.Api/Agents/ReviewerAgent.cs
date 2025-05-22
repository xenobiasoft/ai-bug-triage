using System.Text.Json;
using BugTriageSystem.Api.Models;
using BugTriageSystem.Api.Services;

namespace BugTriageSystem.Api.Agents;

public class ReviewerAgent(IAzureOpenAiService openAiService)
{
    private const string SystemPrompt = "Review the bug report, classification, and fix recommendation. Flag vague or hallucinated suggestions. Return a JSON object with IsValid, Justification, and ConfidenceScore.";

    public async Task<ReviewResult> Review(string bugReport, ClassificationResult classification, RecommendationResult recommendation)
    {
        var prompt = $"""
                      Bug Report: {bugReport}
                      Classification: {JsonSerializer.Serialize(classification)}
                      Recommendation: {JsonSerializer.Serialize(recommendation)}
                      """;

        return await openAiService.GetCompletionAsync<ReviewResult>(prompt, SystemPrompt);
    }
}