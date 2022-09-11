using Application.Features.Dtos;
using Application.Features.Models;
using Application.Services.Repositories;
using AutoMapper;
using corePackages.Application.Request;
using corePackages.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries
{
    public class GetProgrammingLanguageListQuery : IRequest<ProgrammingLanguageListModel>
    {
        public PageRequest PageRequest { get; set; }
    }
    public class GetListProgrammingLanguageQueryHandler : IRequestHandler<GetProgrammingLanguageListQuery, ProgrammingLanguageListModel>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;

        public GetListProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
        }

        public async Task<ProgrammingLanguageListModel> Handle(GetProgrammingLanguageListQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProgrammingLanguage> programmingLanguages = await _programmingLanguageRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

            ProgrammingLanguageListModel mappedProgrammingLanguageListModel = _mapper.Map<ProgrammingLanguageListModel>(programmingLanguages);

            return mappedProgrammingLanguageListModel;
        }
    }
}
