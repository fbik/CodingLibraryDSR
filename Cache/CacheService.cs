using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
namespace Cache;

public class CacheService
{
    private readonly IDistributedCache _cache;

    public CacheService(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task SetAsync<T>(string key, T value, CancellationToken token = default)
    {
        var json = JsonSerializer.Serialize(value);
        var data = Encoding.UTF8.GetBytes(json);
        await _cache.SetAsync(key, data, token);
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        var data = await _cache.GetAsync(key);
        if (data == null)
        {
            return default;
        }

        var json = Encoding.UTF8.GetString(data);
        return JsonSerializer.Deserialize<T>(json);
    }
}