using BugTriageSystem.Api.Agents;

namespace BugTriageSystem.Api.Services;

public class BugTriageOrchestrator(
    ClassifierAgent classifierAgent,
    FixRecommenderAgent fixRecommenderAgent,
    ReviewerAgent reviewerAgent,
    ILogger<BugTriageOrchestrator> logger)
{
    public async Task<TriageResult> ProcessBugReport(string bugReport)
    {
        try
        {
            // Step 1: Classification
            var classification = await classifierAgent.Classify(bugReport);
            logger.LogInformation("Classification completed: {Category}", classification.Classification);

            // Step 2: Fix Recommendation
            var recommendation = await fixRecommenderAgent.Recommend(
                bugReport,
                classification
            );
            logger.LogInformation("Recommendation completed: {Areas}", string.Join(", ", recommendation.AffectedAreas));

            // Step 3: Review
            var review = await reviewerAgent.Review(bugReport, classification, recommendation);
            logger.LogInformation("Review completed: {Confidence}", review.ConfidenceScore);

            return new TriageResult(classification, recommendation, review);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error processing bug report");
            throw;
        }
    }
}