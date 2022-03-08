using Microsoft.AspNetCore.Mvc;
using RedisAPI.Data;
using RedisAPI.Models;

namespace RedisAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlatformController:ControllerBase
    {
        private readonly IPlatformRepo _platRepo;

        public PlatformController(IPlatformRepo PlatRepo)
        {
            _platRepo = PlatRepo;
        }


        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<Platform> GetPlatformById(string Id)
        {
            var platform = _platRepo.getPlatformById(Id);
            if (platform != null)
            {
                return Ok(platform);
            }

            return NotFound();
        }


        [HttpPost]
        public ActionResult<Platform> CreatePlatform(Platform platform)
        {
            _platRepo.CreatPlatform(platform);

            return CreatedAtRoute(nameof(GetPlatformById), new {Id = platform.Id}, platform);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Platform>> GetAllPlatforms()
        {
            return Ok(_platRepo.getAllPlatform());
        }
    }
}
