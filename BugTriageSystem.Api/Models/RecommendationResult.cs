namespace BugTriageSystem.Api.Models;

public class RecommendationResult
{
    public List<string> AffectedAreas { get; set; }
    public string Justification { get; set; }
    public List<string> RelatedPRs { get; set; }
}