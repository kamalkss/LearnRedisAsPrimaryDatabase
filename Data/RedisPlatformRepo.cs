using System.Text.Json;
using RedisAPI.Models;
using StackExchange.Redis;

namespace RedisAPI.Data
{
    public class RedisPlatformRepo : IPlatformRepo
    {
        private readonly IConnectionMultiplexer _connectionMultiPlexer;

        public RedisPlatformRepo(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiPlexer = connectionMultiplexer;
        }

        public void CreatPlatform(Platform platform)
        {
            if (platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }

            var db = _connectionMultiPlexer.GetDatabase();

            var serialPlat = JsonSerializer.Serialize(platform);

            db.StringSet(platform.Id, serialPlat);
        }

        public Platform? getPlatformById(string platformId)
        {
            var db = _connectionMultiPlexer.GetDatabase();

            var platform = db.StringGet(platformId);

            if (!string.IsNullOrEmpty(platform))
            {
                return JsonSerializer.Deserialize<Platform>(platform);
            }

            return null;
        }

        public IEnumerable<Platform> getAllPlatform()
        {
            var db = _connectionMultiPlexer.GetDatabase();
            throw new ArgumentNullException();
        }
    }
}
