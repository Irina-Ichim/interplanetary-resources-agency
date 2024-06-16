using Ira.Api.Models.Dto;
using Ira.Models.Entities;
using Ira.Models.Enums;
using Ira.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ira.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _service;

        public EmployeeController(
            ILogger<EmployeeController> logger,
            IEmployeeService service)
        {
            _logger = logger;
            _service = service;
        }
        // Crear Empleado
        [HttpGet]
        public ActionResult<Employee> GetById([FromQuery] Guid id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return BadRequest("The parameter 'id' cannot be null or empty");
            }

            var employee = _service.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
        //Obtener Empleados por Posición
        [HttpGet("position/{position}")]
        public ActionResult<EmployeeResponse> GetEmployeeByPosition(string position)
        {
            if (position == null || string.IsNullOrWhiteSpace(position))
            {
                return BadRequest("The parameter 'position' cannot be null or empty");
            }

            if (!Enum.TryParse(typeof(EmployeePosition), position, out var pos))
            {
                return BadRequest($"{position} is not a valid value for 'position'");
            }

            var employees = _service.GetEmployeesByPosition((EmployeePosition)pos);

            var result = new List<EmployeeResponse>();

            employees.ForEach((employee) =>
            {
                result.Add(new EmployeeResponse()
                {
                    Id = employee.Id,
                    CompleteName = employee.CompleteName,
                    Email = employee.Email,
                    Position = employee.Position,
                });
            });

            return Ok(result);
        }


        // Actualizar Email del Empleado
        [HttpPut("{id}")]
        public ActionResult<Employee> UpdateEmployee(Guid id, [FromQuery] string email)
        {
            if (email == null || string.IsNullOrWhiteSpace(email))
            {
                return BadRequest("The parameter 'email' cannot be null or empty");
            }

            var employee = _service.UpdateEmployeeEmail(id, email);

            return Ok(employee);
        }

    }
}
