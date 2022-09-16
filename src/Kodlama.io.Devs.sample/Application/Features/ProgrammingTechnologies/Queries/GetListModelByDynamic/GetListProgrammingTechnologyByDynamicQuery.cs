using Application.Features.ProgrammingTechnologies.Models;
using Application.Features.Services.Repositories;
using AutoMapper;
using corePackages.Application.Request;
using corePackages.Persistence.Dynamic;
using corePackages.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ProgrammingTechnologies.Queries.GetListModelByDynamic
{
    public class GetListProgrammingTechnologyByDynamicQuery:IRequest<ProgrammingTechnologyListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }
        public class GetListProgrammingTechnologyByDynamicQueryHandler : IRequestHandler<GetListProgrammingTechnologyByDynamicQuery, ProgrammingTechnologyListModel>
        {
            private readonly IMapper _mapper;
            private readonly IProgrammingTechnologyRepository _modelRepository;
            public GetListProgrammingTechnologyByDynamicQueryHandler(IMapper mapper, IProgrammingTechnologyRepository programmingTechnologyRepository)
            {
                _mapper = mapper;
                _modelRepository = programmingTechnologyRepository;
            }
            public async Task<ProgrammingTechnologyListModel> Handle(GetListProgrammingTechnologyByDynamicQuery request, CancellationToken cancellationToken)
            {
                //car models
                IPaginate<ProgrammingTechnology> models = await _modelRepository.GetListByDynamicAsync(request.Dynamic, include:
                                              m => m.Include(c => c.ProgrammLanguage),
                                              index: request.PageRequest.Page,
                                              size: request.PageRequest.PageSize
                                              );
                //dataModel
                ProgrammingTechnologyListModel mappedTechnologies = _mapper.Map<ProgrammingTechnologyListModel>(models);
                return mappedTechnologies;
            }
        }
    }
}
