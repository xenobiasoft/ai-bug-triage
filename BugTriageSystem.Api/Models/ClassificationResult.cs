namespace BugTriageSystem.Api.Models;

public class ClassificationResult
{
    public string Category { get; set; }
    public string Severity { get; set; }
    public double Confidence { get; set; }
}