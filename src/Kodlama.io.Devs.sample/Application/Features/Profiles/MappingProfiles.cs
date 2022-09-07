using Application.Features.Command;
using Application.Features.Dtos;
using Application.Features.Models;
using AutoMapper;
using corePackages.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();
            CreateMap<ProgrammingLanguage, CreateProgmmingLanguageDto>().ReverseMap();

            CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageCommand>().ReverseMap();
            CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageDto>().ReverseMap();

            CreateMap<ProgrammingLanguage, DeleteProgrammingLanguageCommand>().ReverseMap();
            CreateMap<ProgrammingLanguage, DeleteProgrammingLanguageDto>().ReverseMap();

            CreateMap<IPaginate<ProgrammingLanguage>, ProgrammingLanguageListModel>().ReverseMap();

            CreateMap<ProgrammingLanguage, GetProgrammingLanguageListDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, GetProgrammingLanguageByIdDto>().ReverseMap();
        }
    }
}
