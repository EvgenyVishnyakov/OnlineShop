using Serilog;
using StackExchange.Redis;

namespace OnlineShopWebApp.Redis;

public class RedisCacheService
{
    private readonly IConnectionMultiplexer _redis;
    private readonly SemaphoreSlim mutex = new SemaphoreSlim(1, 1);

    public RedisCacheService(IConnectionMultiplexer redis)
    {
        _redis = redis;
    }

    public async Task SetAsync(string key, string value)
    {
        await mutex.WaitAsync();
        try
        {
            var db = _redis.GetDatabase();
            await db.StringSetAsync(key, value);
        }
        catch (RedisConnectionException ex)
        {
            Log.Error(ex, "Ошибка установления значения в Redis для ключа {key}", key);
        }
        finally
        {
            mutex.Release();
        }
    }

    public async Task<string> TryGetAsync(string key)
    {
        try
        {
            var db = _redis.GetDatabase();
            return await db.StringGetAsync(key);
        }
        catch (RedisConnectionException ex)
        {
            Log.Error(ex, "Ошибка установления значения в Redis для ключа {key}", key);
            return null;
        }
    }

    public async Task RemoveAsync(string key)
    {
        try
        {
            var db = _redis.GetDatabase();
            await db.KeyDeleteAsync(key);
        }
        catch (RedisConnectionException ex)
        {
            Log.Error(ex, "Ошибка удаления значения в Redis для ключа {key}", key);

        }
    }
}
