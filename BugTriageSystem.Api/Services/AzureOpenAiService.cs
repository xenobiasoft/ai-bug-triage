using System.Text.Json;

namespace BugTriageSystem.Api.Services;

public class AzureOpenAiService(
    HttpClient httpClient,
    IConfiguration config,
    ILogger<AzureOpenAiService> logger)
    : IAzureOpenAiService
{
    private readonly ILogger<AzureOpenAiService> _logger = logger;

    public async Task<T> GetCompletionAsync<T>(string prompt, string systemMessage)
    {
        var endpoint = config["AzureOpenAI:Endpoint"];
        var deployment = config["AzureOpenAI:Deployment"];
        var apiKey = config["AzureOpenAI:ApiKey"];

        var body = new
        {
            messages = new[]
            {
                new { role = "system", content = systemMessage },
                new { role = "user", content = prompt }
            },
            temperature = 0.7
        };

        httpClient.DefaultRequestHeaders.Clear();
        httpClient.DefaultRequestHeaders.Add("api-key", apiKey);

        var response = await httpClient.PostAsJsonAsync(
            $"{endpoint}/openai/deployments/{deployment}/chat/completions?api-version=2024-03-01-preview", body);

        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<JsonElement>();

        // Parse the response and convert to T
        // Implementation details omitted for brevity
        return default(T);
    }
}