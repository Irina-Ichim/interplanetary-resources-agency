using Ira.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ira.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class MissionController : ControllerBase
    {
        private readonly ILogger<MissionController> _logger;
        private readonly IMissionService _fakeService;

        public MissionController(
            ILogger<MissionController> logger,
            IMissionService fakeService)
        {
            _logger = logger;
            _fakeService = fakeService;
        }

        //Crear una Misión
        [HttpPost]
        public ActionResult Post()
        {
            var ships = _fakeService.CreateMission();

            return Ok(ships);
        }
    }
}
