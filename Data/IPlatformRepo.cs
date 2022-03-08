using RedisAPI.Models;

namespace RedisAPI.Data
{
    public interface IPlatformRepo
    {
        void CreatPlatform(Platform platform);
        Platform? getPlatformById(string platformId);
        IEnumerable<Platform?>? getAllPlatform();
    }
}
