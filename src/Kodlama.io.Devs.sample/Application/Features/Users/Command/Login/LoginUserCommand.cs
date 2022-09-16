using Application.Features.ProgrammingLanguages.Rules;
using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using corePackages.Security.Dtos;
using corePackages.Security.Encryption;
using corePackages.Security.Entities;
using corePackages.Security.Hashing;
using corePackages.Security.JWT;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Command.Login
{
    public class LoginUserCommand : TokenDto, IRequest<TokenDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public class LoginUseCommandHandler : IRequestHandler<LoginUserCommand, TokenDto>
        {
            private readonly IUserRepository _repository;
            private readonly IMapper _mapper;
            private readonly ITokenHelper _tokenHelper;
            private readonly UserBusinessRules _businessRules;
            public LoginUseCommandHandler(IUserRepository repository, IMapper mapper, ITokenHelper tokenHelper, UserBusinessRules businessRules)
            {
                _repository = repository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
                _businessRules = businessRules;
            }
            public async Task<TokenDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                User user = _repository.Get(user => user.Email == request.Email);
                _businessRules.UserShouldExist(user);
                _businessRules.UserCredentialsShouldMatch(request.Password, user.PasswordHash, user.PasswordSalt);
                List<OperationClaim> operationClaims = new List<OperationClaim>() { };

                foreach (var userOperationClaim in user.UserOperationClaims)
                {
                    operationClaims.Add(userOperationClaim.OperationClaim);
                }
                AccessToken token = _tokenHelper.CreateToken(user, operationClaims);
                TokenDto tokenDto = _mapper.Map<TokenDto>(token);
                return tokenDto;
            }
        }
    }
}
