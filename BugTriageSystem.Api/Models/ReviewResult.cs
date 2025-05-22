using System.Text.Json.Serialization;

namespace BugTriageSystem.Api.Models;

public class ReviewResult
{
    [JsonPropertyName("approved")]
    public bool Approved { get; set; }
    [JsonPropertyName("confidence-score")]
    public double ConfidenceScore { get; set; }
    [JsonPropertyName("justification")]
    public string Justification { get; set; } = string.Empty;
}