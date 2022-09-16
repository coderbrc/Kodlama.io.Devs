using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Queries;
using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Features.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingTechnologies.Queries.GetListModel
{
    public class GetProgrammingTechnologyByIdQuery : IRequest<GetProgrammingTechnologyByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdBrandQueryHandler : IRequestHandler<GetProgrammingTechnologyByIdQuery, GetProgrammingTechnologyByIdDto>
        {
            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
            private readonly IMapper _mapper;

            public async Task<GetProgrammingTechnologyByIdDto> Handle(GetProgrammingTechnologyByIdQuery request, CancellationToken cancellationToken)
            {
                ProgrammingTechnology? programmingTechnology = await _programmingTechnologyRepository.GetAsync(b => b.Id == request.Id);
                return _mapper.Map<GetProgrammingTechnologyByIdDto>(programmingTechnology);
            }
        }
    }
}
