using Application.Features.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using corePackages.Application.Request;
using corePackages.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries
{
    public class GetProgrammingLanguageListQuery : IRequest<GetProgrammingLanguageListDto>
    {
        public PageRequest PageRequest { get; set; }
    }
    public class GetProgrammingLanguageListQueryHandler : IRequestHandler<GetProgrammingLanguageListQuery, GetProgrammingLanguageListDto>
    {
        private readonly IProgrammingLanguageRepository _repository;
        private readonly IMapper _mapper;

        public GetProgrammingLanguageListQueryHandler(IProgrammingLanguageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetProgrammingLanguageListDto> Handle(GetProgrammingLanguageListQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProgrammingLanguage> languageList = await _repository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
            return _mapper.Map<GetProgrammingLanguageListDto>(languageList);
        }
    }
}
