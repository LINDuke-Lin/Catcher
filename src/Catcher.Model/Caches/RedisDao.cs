using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Catcher.Model.Caches
{
    public interface IRedisDao
    {
        bool Set(string key, object data);

        T Get<T>(string key) where T : class;
    }

    public class RedisDao : IRedisDao
    {
        private const string keyHead = "thisResids";

        public readonly IDistributedCache _distributedCache;

        public RedisDao(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        private async Task<bool> SetValus(string key, string value)
        {
            await _distributedCache.SetStringAsync(key, value);
            return true;
        }

        private async Task<string> GetValus(string key)
        {
            return await _distributedCache.GetStringAsync(key);
        }

        /// <summary>
        /// 取值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key) where T : class
        {
            string jsonData = GetValus(key).Result;

            if (string.IsNullOrEmpty(jsonData))
                return null;

            return JsonSerializer.Deserialize<T>(jsonData);
        }

        /// <summary>
        /// 儲存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Set(string key, object data)
        {
            string jsonData = JsonSerializer.Serialize(data);
            return SetValus(key, jsonData).Result;
        }
    }
}
