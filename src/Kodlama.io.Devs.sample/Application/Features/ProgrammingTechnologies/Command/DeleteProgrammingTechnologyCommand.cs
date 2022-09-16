using Application.Features.ProgrammingLanguages.Command;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Features.ProgrammingTechnologies.Rules;
using Application.Features.Services.Repositories;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingTechnologies.Command
{
    public class DeleteProgrammingTechnologyCommand : IRequest<DeleteProgrammingTechnologyDto>
    {
        public int Id { get; set; }
        public class DeleteProgrammingTechnologyCommandHandler : IRequestHandler<DeleteProgrammingTechnologyCommand,DeleteProgrammingTechnologyDto>
        {
            private readonly IProgrammingTechnologyRepository _repository;
            private readonly IMapper _mapper;

            public DeleteProgrammingTechnologyCommandHandler(IProgrammingTechnologyRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<DeleteProgrammingTechnologyDto> Handle(DeleteProgrammingTechnologyCommand request, CancellationToken cancellationToken)
            {
                ProgrammingTechnology technology = _mapper.Map<ProgrammingTechnology>(request);
                ProgrammingTechnology deletedTechnology = await _repository.DeleteAsync(technology);
                return _mapper.Map<DeleteProgrammingTechnologyDto>(deletedTechnology);
            }
        }

    }
}
