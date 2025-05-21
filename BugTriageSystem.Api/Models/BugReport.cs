namespace BugTriageSystem.Api.Models;

public class BugReport
{
    public string Id { get; set; }
    public string Description { get; set; }
    public string Reporter { get; set; }
    public DateTime ReportedAt { get; set; }
}