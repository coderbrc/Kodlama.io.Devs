using Application.Features.ProgrammingLanguages.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Command
{
    public class DeleteProgrammingLanguageCommand : IRequest<DeleteProgrammingLanguageDto>
    {
        public int Id { get; set; }
        public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand, DeleteProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _repository;
            private readonly IMapper _mapper;
            public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<DeleteProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage language = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage deletedLanguage = await _repository.DeleteAsync(language);
                return _mapper.Map<DeleteProgrammingLanguageDto>(deletedLanguage);
            }
        }
    }
}