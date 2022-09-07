using Application.Features.Dtos;
using Application.Features.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
namespace Application.Features.Command
{
    public class CreateProgrammingLanguageCommand : IRequest<CreateProgmmingLanguageDto>
    {
        public string Name { get; set; }
        public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand, CreateProgmmingLanguageDto>
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

            public async Task<CreateProgmmingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.LanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

                ProgrammingLanguage language = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage addedLanguage = await _repository.AddAsync(language);
                CreateProgmmingLanguageDto createProgmmingLanguageDto = _mapper.Map<CreateProgmmingLanguageDto>(addedLanguage);
                return createProgmmingLanguageDto;
            }
        }
    }
}