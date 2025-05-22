using System.Text.Json.Serialization;

namespace BugTriageSystem.Api.Models;

public class ClassificationResult
{
    [JsonPropertyName("classification")]
    public string Classification { get; set; } = string.Empty;
    [JsonPropertyName("justification")]
    public string Justification { get; set; } = string.Empty;
    [JsonPropertyName("confidence-score")]
    public double ConfidenceScore { get; set; }
}