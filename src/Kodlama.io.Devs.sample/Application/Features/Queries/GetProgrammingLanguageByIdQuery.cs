using Application.Features.Dtos;
using Application.Features.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries
{
    public class GetProgrammingLanguageByIdQuery:IRequest<GetProgrammingLanguageByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdBrandQueryHandler : IRequestHandler<GetProgrammingLanguageByIdQuery, GetProgrammingLanguageByIdDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;

            public async Task<GetProgrammingLanguageByIdDto> Handle(GetProgrammingLanguageByIdQuery request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage? programmingLanguage =await _programmingLanguageRepository.GetAsync(b => b.Id == request.Id);
                return _mapper.Map<GetProgrammingLanguageByIdDto>(programmingLanguage);
            }
        }
    }
}
