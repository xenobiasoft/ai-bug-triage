﻿using System.Text.Json;
using BugTriageSystem.Api.Models;
using BugTriageSystem.Api.Services;

namespace BugTriageSystem.Api.Agents;

public class FixRecommenderAgent(IAzureOpenAiService openAiService)
{
    private const string SystemPrompt = "Based on this bug report and its classification, suggest likely modules, files, or components. Include a brief justification. Return a JSON object with affected-areas, justification, recommendation, and confidence-score between 0 and 1.";

    public async Task<RecommendationResult> Recommend(string bugReport, ClassificationResult classification)
    {
        var prompt = $"""
                      Bug Report: {bugReport}
                      Classification: {JsonSerializer.Serialize(classification)}
                      """;

        return await openAiService.GetCompletionAsync<RecommendationResult>(prompt, SystemPrompt);
    }
}