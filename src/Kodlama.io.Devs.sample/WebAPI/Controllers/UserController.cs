using Application.Features.Users.Command.Login;
using Application.Features.Users.Command.Registiration;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Register")]
       public async Task<IActionResult> Register([FromBody] CreateUserCommand createUserCommand)
        {
            var result = await _mediator.Send(createUserCommand);

            return Ok(result);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand loginUserCommand)
        {
            var result = await _mediator.Send(loginUserCommand);

            return Ok(result);
        }
    }
}
