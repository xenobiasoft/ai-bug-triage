namespace BugTriageSystem.Api.Models;

public class ReviewResult
{
    public bool IsValid { get; set; }
    public double Confidence { get; set; }
    public string Comments { get; set; }
}