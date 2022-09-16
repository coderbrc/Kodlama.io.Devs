using Application.Features.UserGithubs.Command;
using Application.Features.UserGithubs.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGithubController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateUserGithubCommand createCommand)
        {
            CreateUserGithubDto result = await Mediator.Send(createCommand);
            return Created("", result);
        }
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete([FromBody] DeleteUserGithubCommand deleteCommand)
        {
            DeleteUserGithubDto deleted = await Mediator.Send(deleteCommand);
            return Ok(deleted);
        }
        [HttpPut("Update/{Id}")]
        public async Task<IActionResult> Update([FromBody] UpdateUserGithubCommand updateCommand)
        {
            UpdateUserGithubDto updated = await Mediator.Send(updateCommand);
            return Ok(updated);
        }
    }
}
