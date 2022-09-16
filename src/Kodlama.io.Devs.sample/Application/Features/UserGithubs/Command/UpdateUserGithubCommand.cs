using Application.Features.Services.Repositories;
using Application.Features.UserGithubs.Dtos;
using Application.Features.UserGithubs.Rules;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserGithubs.Command
{
    public class UpdateUserGithubCommand:IRequest<UpdateUserGithubDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GithubAdress { get; set; }
        public class UpdateUserGithubCommandHandler : IRequestHandler<UpdateUserGithubCommand, UpdateUserGithubDto>
        {
            private readonly IUserGithubRepository _repository;
            private readonly IMapper _mapper;
            private readonly UserGithubBusinessRules _businessRules;

            public UpdateUserGithubCommandHandler(IUserGithubRepository repository, IMapper mapper, UserGithubBusinessRules businessRules)
            {
                _repository = repository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<UpdateUserGithubDto> Handle(UpdateUserGithubCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.TechnologyNameCanNotBeDuplicatedWhenInserted(request.GithubAdress);

                UserGithub userGithub = _mapper.Map<UserGithub>(request);
                UserGithub updatedTechnology = await _repository.UpdateAsync(userGithub);
                return _mapper.Map<UpdateUserGithubDto>(updatedTechnology);
            }
        }
    }
}
