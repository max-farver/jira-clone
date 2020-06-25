using System.Collections.Generic;
using System.Threading.Tasks;
using DiscountJira.Core.Models;

namespace DiscountJira.Core.Services.ProjectService
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetProjects();
        Task<Project> GetProjectById(int Id);
        Task<bool> CreateProject(Project projectToCreate);
        Task<bool> UpdateProject(Project oldProject, Project updatedProject);
        Task<bool> DeleteProject(Project projectToDelete);
    }
}