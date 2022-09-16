using Application.Features.UserGithubs.Command;
using Application.Features.UserGithubs.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserGithubs.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserGithub, CreateUserGithubCommand>().ReverseMap();
            CreateMap<UserGithub, CreateUserGithubDto>().ReverseMap();

            CreateMap<UserGithub, DeleteUserGithubCommand>().ReverseMap();
            CreateMap<UserGithub, DeleteUserGithubDto>().ReverseMap();

            CreateMap<UserGithub, UpdateUserGithubCommand>().ReverseMap();
            CreateMap<UserGithub, UpdateUserGithubDto>().ReverseMap();
        }
    }
}
