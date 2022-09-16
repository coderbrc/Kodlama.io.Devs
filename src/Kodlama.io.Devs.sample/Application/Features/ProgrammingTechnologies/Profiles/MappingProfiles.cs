using Application.Features.ProgrammingLanguages.Command;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingTechnologies.Command;
using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Features.ProgrammingTechnologies.Models;
using AutoMapper;
using corePackages.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProgrammingTechnologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingTechnology, CreateProgrammingTechnologyCommand>().ReverseMap();
            CreateMap<ProgrammingTechnology, CreateProgrammingTechnologyDto>().ReverseMap();
                      
            CreateMap<ProgrammingTechnology, DeleteProgrammingTechnologyCommand>().ReverseMap();
            CreateMap<ProgrammingTechnology, DeleteProgrammingTechnologyDto>().ReverseMap();

            CreateMap<ProgrammingTechnology, UpdateProgrammingTechnologyCommand>().ReverseMap();
            CreateMap<ProgrammingTechnology, UpdateProgrammingTechnologyDto>().ReverseMap();

            CreateMap<IPaginate<ProgrammingTechnology>, ProgrammingTechnologyListModel>().ReverseMap();

            CreateMap<ProgrammingTechnology, GetProgrammingTechnologyListDto>()
                .ForMember(c => c.ProgrammingLanguageName, opt => opt.MapFrom(c => c.ProgrammLanguage.Name)).ReverseMap();
            CreateMap<ProgrammingTechnology, GetProgrammingTechnologyByIdDto>().ReverseMap();
        }
    }
}
