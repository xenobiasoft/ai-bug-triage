namespace BugTriageSystem.Api.Services;

public interface IAzureOpenAiService
{
    Task<T> GetCompletionAsync<T>(string prompt, string systemMessage);
}