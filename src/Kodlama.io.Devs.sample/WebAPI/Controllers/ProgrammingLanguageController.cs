using Application.Features.Command;
using Application.Features.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguageController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand createCommand)
        {
            CreateProgmmingLanguageDto result = await Mediator.Send(createCommand);
            return Created("", result);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromBody] DeleteProgrammingLanguageCommand deleteCommand)
        {
            DeleteProgrammingLanguageDto deleted = await Mediator.Send(deleteCommand);
            return Ok(deleted);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageCommand updateCommand)
        {
            UpdateProgrammingLanguageDto updated = await Mediator.Send(updateCommand);
            return Ok(updated);
        }
    }
}
