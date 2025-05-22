namespace BugTriageSystem.Api.Models;

public class ReviewResult
{
    public bool IsValid { get; set; }
    public double ConfidenceScore { get; set; }
    public string Justification { get; set; } = string.Empty;
}