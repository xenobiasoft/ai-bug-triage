using System.Text.Json;

namespace BugTriageSystem.Api.Services;

public class AzureOpenAiService(HttpClient httpClient, IConfiguration config) : IAzureOpenAiService
{
    public async Task<TResponseType?> GetCompletionAsync<TResponseType>(string prompt, string systemMessage)
    {
        var endpoint = config["AzureOpenAI:Endpoint"];
        var deployment = config["AzureOpenAI:Deployment"];
        var apiKey = config["AzureOpenAI:ApiKey"];

        httpClient.DefaultRequestHeaders.Clear();
        httpClient.DefaultRequestHeaders.Add("api-key", apiKey);

        var requestData = new
        {
            messages = new[]
            {
                new { role = "system", content = systemMessage },
                new { role = "user", content = prompt }
            }
        };

        var requestUri = $"{endpoint}/openai/deployments/{deployment}/chat/completions?api-version=2025-01-01-preview";
        var response = await httpClient.PostAsJsonAsync(requestUri, requestData);
        
        response.EnsureSuccessStatusCode();

        var parsedResponse = ExtractResponse(await response.Content.ReadAsStringAsync(CancellationToken.None)).Replace("```json", string.Empty).Replace("```", string.Empty);

        return JsonSerializer.Deserialize<TResponseType>(parsedResponse);
    }

    static string ExtractResponse(string responseJson)
    {
        using var doc = JsonDocument.Parse(responseJson);
        var root = doc.RootElement;

        try
        {
            var message = root
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            return message?.Trim() ?? "[No response]";
        }
        catch
        {
            return "[Unable to parse response]";
        }
    }
}