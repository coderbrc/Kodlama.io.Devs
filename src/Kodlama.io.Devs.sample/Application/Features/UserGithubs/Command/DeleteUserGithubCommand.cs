using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.Services.Repositories;
using Application.Features.UserGithubs.Dtos;
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
    public class DeleteUserGithubCommand:IRequest<DeleteUserGithubDto>
    {
        public int Id { get; set; }
        public class DeleteUserGithubCommandHandler : IRequestHandler<DeleteUserGithubCommand, DeleteUserGithubDto>
        {
            private readonly IUserGithubRepository _repository;
            private readonly IMapper _mapper;

            public DeleteUserGithubCommandHandler(IUserGithubRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<DeleteUserGithubDto> Handle(DeleteUserGithubCommand request, CancellationToken cancellationToken)
            {
                UserGithub userGithub = _mapper.Map<UserGithub>(request);
                UserGithub deletedUserGithub = await _repository.DeleteAsync(userGithub);
                return _mapper.Map<DeleteUserGithubDto>(deletedUserGithub);
            }
        }
    }
}
