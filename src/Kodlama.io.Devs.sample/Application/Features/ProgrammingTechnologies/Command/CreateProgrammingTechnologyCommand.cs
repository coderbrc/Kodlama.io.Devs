using Application.Features.ProgrammingLanguages.Command;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Features.ProgrammingTechnologies.Rules;
using Application.Features.Services.Repositories;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingTechnologies.Command
{
    public class CreateProgrammingTechnologyCommand : IRequest<CreateProgrammingTechnologyDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProgrammingLanguageId { get; set; }
        public class CreateProgrammingTechnologyCommandHandler : IRequestHandler<CreateProgrammingTechnologyCommand, CreateProgrammingTechnologyDto>
        {
            private readonly IProgrammingTechnologyRepository _repository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyBusinessRules _businessRules;

            public CreateProgrammingTechnologyCommandHandler(IProgrammingTechnologyRepository repository, IMapper mapper, ProgrammingTechnologyBusinessRules businessRules)
            {
                _repository = repository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<CreateProgrammingTechnologyDto> Handle(CreateProgrammingTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.TechnologyNameCanNotBeDuplicatedWhenInserted(request.Name);

                ProgrammingTechnology technology = _mapper.Map<ProgrammingTechnology>(request);
                ProgrammingTechnology createdTechnology = await _repository.AddAsync(technology);
                return _mapper.Map<CreateProgrammingTechnologyDto>(createdTechnology);
            }
        }
    }
}