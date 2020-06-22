using Application.Projects.DTOs;
using AutoMapper;
using Domain;

namespace Application.Projects.Mappings {
    public class ProjectMappings : Profile {
        public ProjectMappings() {
            CreateMap<Project, ProjectGetDto>().ReverseMap();
        }
    }
}