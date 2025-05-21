using BugTriageSystem.Api.Models;

namespace BugTriageSystem.Api.Services;

public record TriageResult(ClassificationResult Classification, RecommendationResult Recommendation, ReviewResult Review);