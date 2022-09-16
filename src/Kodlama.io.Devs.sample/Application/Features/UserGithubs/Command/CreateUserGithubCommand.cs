using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Features.Services.Repositories;
using Application.Features.UserGithubs.Dtos;
using Application.Features.UserGithubs.Rules;
using AutoMapper;
using corePackages.Persistence.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserGithubs.Command
{
    public class CreateUserGithubCommand:IRequest<CreateUserGithubDto>
    {
        public int UserId { get; set; }
        public string GithubAdress { get; set; }
        public class CreateUserGithubCommandHandler : IRequestHandler<CreateUserGithubCommand, CreateUserGithubDto>
        {
            private readonly IUserGithubRepository _repository;
            private readonly IMapper _mapper;
            private readonly UserGithubBusinessRules _businessRules;

            public CreateUserGithubCommandHandler(IUserGithubRepository repository, IMapper mapper, UserGithubBusinessRules businessRules)
            {
                _repository = repository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<CreateUserGithubDto> Handle(CreateUserGithubCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.TechnologyNameCanNotBeDuplicatedWhenInserted(request.GithubAdress);

                UserGithub userGithub = _mapper.Map<UserGithub>(request);
                UserGithub createdTechnology = await _repository.AddAsync(userGithub);
                return _mapper.Map<CreateUserGithubDto>(createdTechnology);
            }
        }
    }
}
