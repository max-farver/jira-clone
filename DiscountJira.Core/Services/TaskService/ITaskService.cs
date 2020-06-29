using System.Collections.Generic;
using System.Threading.Tasks;
using DiscountJira.Core.Models;

namespace DiscountJira.Core.Services.ProjectService
{
    public interface ITaskService
    {
        Task<bool> CreateTask(Project projectToCreate);
        Task<bool> UpdateTask(Project oldProject, Project updatedProject);
        Task<bool> DeleteTask(Project projectToDelete);
    }
}