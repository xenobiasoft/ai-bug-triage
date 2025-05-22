namespace BugTriageSystem.Api.Models;

public class ClassificationResult
{
    public string Classification { get; set; } = string.Empty;
    public string Justification { get; set; } = string.Empty;
    public double ConfidenceScore { get; set; }
}