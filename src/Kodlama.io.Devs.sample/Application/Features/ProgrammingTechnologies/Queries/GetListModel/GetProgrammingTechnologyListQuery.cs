using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguages.Queries;
using Application.Features.ProgrammingTechnologies.Models;
using Application.Features.Services.Repositories;
using Application.Services.Repositories;
using AutoMapper;
using corePackages.Application.Request;
using corePackages.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingTechnologies.Queries.GetListModel
{
    public class GetProgrammingTechnologyListQuery : IRequest<ProgrammingTechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }
    }
    public class GetListProgrammingTechnologyQueryHandler : IRequestHandler<GetProgrammingTechnologyListQuery, ProgrammingTechnologyListModel>
    {
        private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
        private readonly IMapper _mapper;

        public GetListProgrammingTechnologyQueryHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper)
        {
            _programmingTechnologyRepository = programmingTechnologyRepository;
            _mapper = mapper;
        }

        public async Task<ProgrammingTechnologyListModel> Handle(GetProgrammingTechnologyListQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProgrammingTechnology> programmingTechnologies = await _programmingTechnologyRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

            ProgrammingTechnologyListModel mappedProgrammingTechnologyListModel = _mapper.Map<ProgrammingTechnologyListModel>(programmingTechnologies);

            return mappedProgrammingTechnologyListModel;
        }
    }
}
