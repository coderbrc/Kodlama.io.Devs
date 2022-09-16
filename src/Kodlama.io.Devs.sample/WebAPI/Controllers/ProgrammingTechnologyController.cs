using Application.Features.ProgrammingLanguages.Command;
using Application.Features.ProgrammingTechnologies.Command;
using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Features.ProgrammingTechnologies.Models;
using Application.Features.ProgrammingTechnologies.Queries.GetListModel;
using Application.Features.ProgrammingTechnologies.Queries.GetListModelByDynamic;
using corePackages.Application.Request;
using corePackages.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class ProgrammingTechnologyController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingTechnologyCommand createCommand)
        {
            CreateProgrammingTechnologyDto result = await Mediator.Send(createCommand);
            return Created("", result);
        }
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete([FromBody] DeleteProgrammingTechnologyCommand deleteCommand)
        {
            DeleteProgrammingTechnologyDto deleted = await Mediator.Send(deleteCommand);
            return Ok(deleted);
        }
        [HttpPut("Update/{Id}")]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingTechnologyCommand updateCommand)
        {
            UpdateProgrammingTechnologyDto updated = await Mediator.Send(updateCommand);
            return Ok(updated);
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetProgrammingTechnologyListQuery getListProgrammingTechnologyQuery = new() { PageRequest = pageRequest };
            ProgrammingTechnologyListModel result = await Mediator.Send(getListProgrammingTechnologyQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetProgrammingTechnologyByIdQuery getByIdIdTechnologyQuery)
        {
            GetProgrammingTechnologyByIdDto technologyGetByIdDto = await Mediator.Send(getByIdIdTechnologyQuery);
            return Ok(technologyGetByIdDto);
        }
        [HttpPost("Get/GetByDynamic")]
        public async Task<ActionResult> GetByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic, CancellationToken cancellationToken)
        {
            GetListProgrammingTechnologyByDynamicQuery getListProgrammingTechnologyByDynamicQuery = new GetListProgrammingTechnologyByDynamicQuery { Dynamic = dynamic, PageRequest = pageRequest };
            var result = await Mediator.Send(getListProgrammingTechnologyByDynamicQuery);
            return Ok(result);
        }
    }
}
