using Application.Features.Dtos;
using Application.Features.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Command
{
    public class UpdateProgrammingLanguageCommand : IRequest<UpdateProgrammingLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommand, UpdateProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _repository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _businessRules;

            public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository repository, IMapper mapper,
                ProgrammingLanguageBusinessRules businessRules)
            {
                _repository = repository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<UpdateProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.LanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

                ProgrammingLanguage language = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage updatedLanguage = await _repository.UpdateAsync(language);
                return _mapper.Map<UpdateProgrammingLanguageDto>(updatedLanguage);
            }
        }
    }
}