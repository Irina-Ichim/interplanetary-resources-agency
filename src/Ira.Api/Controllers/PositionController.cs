using Ira.Models.Enums;
using Ira.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ira.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class PositionController : ControllerBase
    {
        private readonly ILogger<PositionController> _logger;

        public PositionController(
            ILogger<PositionController> logger)

        {
            _logger = logger;
        }
        //Obtener Posiciones
        [HttpGet]
        public ActionResult GetPositions()
        {
            return Ok(Utilities.GetEnumValues<EmployeePosition>());
        }
    }
}
