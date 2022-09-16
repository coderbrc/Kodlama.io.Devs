using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Features.ProgrammingTechnologies.Rules;
using Application.Features.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingTechnologies.Command
{
    public class UpdateProgrammingTechnologyCommand : IRequest<UpdateProgrammingTechnologyDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public class UpdateProgrammingTechnologyCommandHandler : IRequestHandler<UpdateProgrammingTechnologyCommand, UpdateProgrammingTechnologyDto>
        {
            private readonly IProgrammingTechnologyRepository _repository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyBusinessRules _businessRules;

            public UpdateProgrammingTechnologyCommandHandler(IProgrammingTechnologyRepository repository, IMapper mapper, ProgrammingTechnologyBusinessRules businessRules)
            {
                _repository = repository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<UpdateProgrammingTechnologyDto> Handle(UpdateProgrammingTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.TechnologyNameCanNotBeDuplicatedWhenInserted(request.Name);

                ProgrammingTechnology technology = _mapper.Map<ProgrammingTechnology>(request);
                ProgrammingTechnology updatedTechnology = await _repository.UpdateAsync(technology);
                return _mapper.Map<UpdateProgrammingTechnologyDto>(updatedTechnology);
            }
        }
    }
}
