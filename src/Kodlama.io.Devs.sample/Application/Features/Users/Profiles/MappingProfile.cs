using Application.Features.Users.Command.Login;
using Application.Features.Users.Command.Registiration;
using Application.Features.Users.Dtos;
using AutoMapper;
using corePackages.Security.Entities;
using corePackages.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, LoginUserCommand>().ReverseMap();
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, TokenDto>().ReverseMap();
        }
    }
}
