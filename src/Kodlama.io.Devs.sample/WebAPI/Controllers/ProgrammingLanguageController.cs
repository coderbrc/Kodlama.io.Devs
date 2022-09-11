using Application.Features.Command;
using Application.Features.Dtos;
using Application.Features.Models;
using Application.Features.Queries;
using corePackages.Application.Request;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguageController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand createCommand)
        {
            CreateProgmmingLanguageDto result = await Mediator.Send(createCommand);
            return Created("", result);
        }
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete([FromBody] DeleteProgrammingLanguageCommand deleteCommand)
        {
            DeleteProgrammingLanguageDto deleted = await Mediator.Send(deleteCommand);
            return Ok(deleted);
        }
        [HttpPut("Update/{Id}")]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageCommand updateCommand)
        {
            UpdateProgrammingLanguageDto updated = await Mediator.Send(updateCommand);
            return Ok(updated);
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetProgrammingLanguageListQuery getListProgrammingLanguageQuery = new() { PageRequest = pageRequest };
            ProgrammingLanguageListModel result = await Mediator.Send(getListProgrammingLanguageQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetProgrammingLanguageByIdQuery getByIdIdBrandQuery)
        {
            GetProgrammingLanguageByIdDto brandGetByIdDto = await Mediator.Send(getByIdIdBrandQuery);
            return Ok(brandGetByIdDto);
        }
    }
}
