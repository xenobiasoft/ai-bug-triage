using System.Text.Json.Serialization;

namespace BugTriageSystem.Api.Models;

public class RecommendationResult
{
    [JsonPropertyName("affected-areas")]
    public List<string> AffectedAreas { get; set; } = [];
    [JsonPropertyName("justification")]
    public string Justification { get; set; } = string.Empty;
    [JsonPropertyName("recommendation")]
    public string Recommendation { get; set; } = string.Empty;
    [JsonPropertyName("confidence-score")]
    public double ConfidenceScore { get; set; }
}