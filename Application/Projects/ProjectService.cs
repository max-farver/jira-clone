using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Projects.DTOs;
using AutoMapper;
using Domain;

namespace Application.Projects
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectGetDto>> GetProjects();
        Task<ProjectGetDto> GetProjectById(int Id);
        void CreateProject(ProjectCreateDto projectToCreate);
        void UpdateProject(ProjectUpdateDto projectToUpdate);
        void DeleteProject(int Id);
    }
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IProjectRepository Projects;

        public ProjectService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            Projects = unitOfWork.Projects;
        }

        public async Task<IEnumerable<ProjectGetDto>> GetProjects()
        {
            var projects = await Projects.GetAll();
            var projectsToReturn = _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectGetDto>>(projects);
            return projectsToReturn;
        }

        public async Task<ProjectGetDto> GetProjectById(int Id)
        {
            var project = await Projects.Get(Id);
            var projectToReturn = _mapper.Map<Project, ProjectGetDto>(project);
            return projectToReturn;
        }

        public void CreateProject(ProjectCreateDto projectToCreate)
        {
            Projects.Add(_mapper.Map<ProjectCreateDto, Project>(projectToCreate));
            _unitOfWork.Complete();
        }

        public async void UpdateProject(ProjectUpdateDto projectToUpdate)
        {
            var project = await Projects.Get(projectToUpdate.Id);
            project.Name = projectToUpdate.Name ?? project.Name;
            project.Description = projectToUpdate.Description ?? project.Description;
            project.Version = projectToUpdate.Version != 0 ? projectToUpdate.Version : project.Version;
            project.Members = projectToUpdate.Members ?? project.Members;
            Projects.Add(project);
            _unitOfWork.Complete();
        }

        public async void DeleteProject(int Id)
        {
            var project = await Projects.Get(Id);
            Projects.Remove(project);
            _unitOfWork.Complete();
        }
    }
}