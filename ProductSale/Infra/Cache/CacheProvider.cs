using System.Text.Json;
using StackExchange.Redis;

namespace ProductSale.Infra.Cache
{
    public class CacheProvider : ICacheProvider
    {
        private readonly IDatabase _cacheDb;

        public CacheProvider()
        {
            var redis = ConnectionMultiplexer.Connect("redis:6379");
            _cacheDb = redis.GetDatabase();
        }

        public T Get<T>(string key)
        {
            var value = _cacheDb.StringGet(key);

            if (String.IsNullOrEmpty(value))
                return default;

            return JsonSerializer.Deserialize<T>(value);
        }

        public void DeleteCache(string key) => _cacheDb.KeyDelete(key);

        public void Set<T>(string key, T value)
        {
            var expirationTime = DateTimeOffset.Now.AddSeconds(3600).DateTime.Subtract(DateTime.Now);
            _cacheDb.StringSet(key, JsonSerializer.Serialize(value), expirationTime);
        }
    }
}
