using BugTriageSystem.Api.Models;

namespace BugTriageSystem.Api.Validators;

public class ValidationException(string message) : Exception(message);

public static class BugReportValidator
{
    public static void Validate(BugReport bugReport)
    {
        if (string.IsNullOrWhiteSpace(bugReport.Description))
            throw new ValidationException("Bug report description cannot be empty");

        if (string.IsNullOrWhiteSpace(bugReport.Reporter))
            throw new ValidationException("Reporter information is required");
    }
}