using System.Text.Json;
using Web.Pages.Problems.Models;

namespace Web.Pages.Problems.Service;

public class ProblemsService
{
    private readonly HttpClient _httpClient;

    public ProblemsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<ProblemsListItem>> GetProblems(int offset = 0, int limit = 10)
    {
        string url = $"{Settings.ApiRoot}/problems?offset={offset}&limit={limit}";

        var response = await _httpClient.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        var data = JsonSerializer.Deserialize<IEnumerable<ProblemsListItem>>(content, new JsonSerializerOptions());

        return data;
    }

    public async Task<ProblemsListItem> GetProblems(int ProblemsId)
    {
        string url = $"{Settings.ApiRoot}/problems/{ProblemsId}";

        var response = await _httpClient.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        var data = JsonSerializer.Deserialize<ProblemsListItem>(content, new JsonSerializerOptions());

        return data;
    }
}