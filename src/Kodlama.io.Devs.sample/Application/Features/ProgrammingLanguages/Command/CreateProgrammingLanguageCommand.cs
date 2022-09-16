using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Domain.Entities;

namespace Application.Features.ProgrammingLanguages.Command
{
    public class CreateProgrammingLanguageCommand : IRequest<CreateProgrammingLanguageDto>
    {
        public string Name { get; set; }
        public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand, CreateProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _repository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _businessRules;
            public CreateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository repository, IMapper mapper,
               ProgrammingLanguageBusinessRules businessRules)
            {
                _repository = repository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<CreateProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.LanguageNameCanNotBeDuplicatedWhenInserted(request.Name);
                ProgrammingLanguage language = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage addedLanguage = await _repository.AddAsync(language);
                CreateProgrammingLanguageDto createProgmmingLanguageDto = _mapper.Map<CreateProgrammingLanguageDto>(addedLanguage);
                return createProgmmingLanguageDto;
            }
        }
    }
}
