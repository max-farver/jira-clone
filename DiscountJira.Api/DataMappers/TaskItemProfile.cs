using AutoMapper;
using DiscountJira.Api.Dtos;
using DiscountJira.Core.Models;

namespace DiscountJira.Api.DataMappers
{
    public class TaskItemProfile : Profile
    {
        public TaskItemProfile()
        {
            CreateMap<TaskItem, TaskItemDto>();
        }
    }
}