namespace BugTriageSystem.Api.Models;

public class RecommendationResult
{
    public List<string> AffectedAreas { get; set; } = [];
    public string Justification { get; set; } = string.Empty;
    public string Recommendation { get; set; } = string.Empty;
    public double ConfidenceScore { get; set; }
}