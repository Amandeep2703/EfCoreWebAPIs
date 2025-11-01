using EfCoreWebAPIs.Application.Commands.EmployeeCommands;
using EfCoreWebAPIs.Application.Queries.EmployeeQueries;
using EfCoreWebAPIs.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddEmployeeAsync([FromBody] Employee emloyee)
        {
            var result = await _mediator.Send(new AddEmployeeCommand(emloyee));
            return Ok(result);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllEmployeeAsync()
        {
            var result = await _mediator.Send(new GetAllEmployeesQuery());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeByIdAsync([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new GetEmployeeById(id));
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeById([FromRoute] Guid id, [FromBody] Employee emp)
        {
            var result = await _mediator.Send(new UpdateEmployeeCommand(id,emp));
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeById([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new DeleteEmployeeCommand(id));
            return Ok(result);
        }
    }
}
