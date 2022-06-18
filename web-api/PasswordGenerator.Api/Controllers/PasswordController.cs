using MediatR;
using Microsoft.AspNetCore.Mvc;
using PasswordGenerator.Application.Password.Commands.CreatePassword;

namespace PasswordGenerator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PasswordController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePasswordForUser([FromBody] string userId)
        {
            var command = new CreatePasswordCommand(userId);
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
