using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using corePackages.Security.Dtos;
using corePackages.Security.Entities;
using corePackages.Security.Hashing;
using corePackages.Security.JWT;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Command.Registiration
{
    public class CreateUserCommand: UserForRegisterDto, IRequest<RegisterUserDto>
    {
        public class CreateCommandHandler : IRequestHandler<CreateUserCommand, RegisterUserDto>
        {
            private readonly IUserRepository _repository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _businessRules;
            private readonly ITokenHelper _tokenhelper;

            public CreateCommandHandler(IUserRepository repository, IMapper mapper, UserBusinessRules businessRules, ITokenHelper tokenhelper)
            {
                _repository = repository;
                _mapper = mapper;
                _businessRules = businessRules;
                _tokenhelper = tokenhelper;
            }

            public async Task<RegisterUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.EmailCanNotBeDuplicatedWhenInserted(request.Email);
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
                UserofCreate userofCreate = _mapper.Map<UserofCreate>(request);
                userofCreate.PasswordHash = passwordHash;   
                userofCreate.PasswordSalt = passwordSalt;
                var createdDeveloper = await _repository.AddAsync(userofCreate);
                var token = _tokenhelper.CreateToken(userofCreate, new List<OperationClaim>());

                return new() { Token = token.Token, Expiration = token.Expiration };
            }
        }
    }
}
