using System.Collections.Generic;
using System.Threading.Tasks;
using DiscountJira.Core.Interfaces;
using DiscountJira.Core.Interfaces.Repositories;
using DiscountJira.Core.Models;

namespace DiscountJira.Core.Services.ProjectService
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProjectRepository _projects;

        public ProjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _projects = unitOfWork.Projects;
        }
        public async Task<IEnumerable<Project>> GetProjects(bool includeTasks)
        {
            if (includeTasks)
                return await _projects.GetProjectsWithTasks();
            return await _projects.GetAll();
        }
        public async Task<Project> GetProjectById(int Id, bool includeTasks)
        {
            if (includeTasks)
                return await _projects.GetProjectByIdWithTasks(Id);
            return await _projects.Get(Id);

        }
        public async Task<bool> CreateProject(Project projectToCreate)
        {
            _projects.Add(projectToCreate);
            return (await _unitOfWork.Complete()) > 0;
        }
        public async Task<bool> UpdateProject(Project oldProject, Project updatedProject)
        {
            oldProject.Name = updatedProject.Name ?? oldProject.Name;
            oldProject.Description = updatedProject.Description ?? oldProject.Description;
            oldProject.Version = updatedProject.Version != 0 ? updatedProject.Version : oldProject.Version;
            oldProject.Members = updatedProject.Members != null ? updatedProject.Members : oldProject.Members;
            // _projects.Add(oldProject);
            return (await _unitOfWork.Complete()) > 0;
        }
        public async Task<bool> DeleteProject(Project projectToDelete)
        {
            _projects.Remove(projectToDelete);
            return (await _unitOfWork.Complete()) > 0;
        }

    }
}