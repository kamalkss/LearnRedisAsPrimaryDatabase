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
                return Ok();
            }

            return NotFound();
        }

    }
}
