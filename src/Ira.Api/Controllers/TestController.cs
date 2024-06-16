using Ira.Api.Models.Dto;
using Ira.Services.Interfaces;
using Ira.Services.Model;
using Microsoft.AspNetCore.Mvc;

namespace Ira.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly IEmailService _emailService;

        public TestController(
            ILogger<TestController> logger,
            IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        //Enviar Correo Electrónico
        [HttpPost("SendEmail")]
        public ActionResult SendEmail(SendEmailRequest request)
        {
            if (request == null)
            {
                return BadRequest(request);
            }

            var message = new Message(
                to: request.To,
                subject: request.Subject,
                content: request.Content);

            _emailService.SendEmail(message);

            return Ok();
        }
    }
}
