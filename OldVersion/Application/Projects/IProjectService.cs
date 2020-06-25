using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Projects.DTOs;

namespace Application.Projects
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectGetDto>> GetProjects();
        Task<ProjectGetDto> GetProjectById(int Id);
        void CreateProject(ProjectCreateDto projectToCreate);
        Task UpdateProject(ProjectUpdateDto projectToUpdate);
        Task DeleteProject(int Id);
    }
}