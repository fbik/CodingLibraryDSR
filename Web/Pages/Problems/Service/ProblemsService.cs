using System.Text;
using System.Text.Json;
using Web.Pages.Problems.Models;
using Web.Pages.Problems.Models;
namespace Web.Pages.Problems.Service;

public class ProblemsService
{
    //private readonly ProblemsService _problemsService;
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

        var data = JsonSerializer.Deserialize<IEnumerable<ProblemsListItem>>(content,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<ProblemsListItem>();

        return data;
    }

    public async Task<ProblemsListItem> GetProblems(int problemsUid)
    {
        string url = $"{Settings.ApiRoot}/problems/{problemsUid}";

        var response = await _httpClient.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        var data = JsonSerializer.Deserialize<ProblemsListItem>(content, new
            JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new ProblemsListItem();

        return data;
    }

    public async Task AddProblems(ProblemsModel model)
    {
        string url = $"{Settings.ApiRoot}/problems";

        var body = JsonSerializer.Serialize(model);
        var request = new StringContent(body, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(url, request);

        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
    }    
    
    public async Task EditProblems(Guid problemsUid, ProblemsModel model)
    {
        string url = $"{Settings.ApiRoot}/problems/{problemsUid}";

        var body = JsonSerializer.Serialize(model);
        var request = new StringContent(body, Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync(url, request);

        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
    }

    public async Task DeleteProblems(Guid problemsUid)
    {
        string url = $"{Settings.ApiRoot}/problems/{problemsUid}";

        var response = await _httpClient.DeleteAsync(url);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }
    }

    public async Task<IEnumerable<CategoriesModel>> GetCategoriesList()
    {
        string url = $"{Settings.ApiRoot}/categories";

        var response = await _httpClient.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        var data = JsonSerializer.Deserialize<IEnumerable<CategoriesModel>>(content,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<CategoriesModel>();

        return data;
    }
}
