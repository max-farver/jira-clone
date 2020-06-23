using Application.Projects.DTOs;
using AutoMapper;
using Domain.Projects;

namespace Application.Projects
{
    public class ProjectMappings : Profile
    {
        public ProjectMappings()
        {
            CreateMap<Project, ProjectGetDto>().ReverseMap();
            CreateMap<Project, ProjectCreateDto>().ReverseMap();
        }
    }
}