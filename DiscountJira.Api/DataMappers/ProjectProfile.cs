using AutoMapper;
using DiscountJira.Api.Dtos;
using DiscountJira.Core.Models;

namespace DiscountJira.Api.DataMappers
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            this.CreateMap<Project, ProjectDto>();
        }
    }
}