using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Projects;
using Application.Projects.DTOs;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        /// <summary>
        /// Get a list of projects.
        /// </summary>
        /// <returns>A list of all projects.</returns>
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ProjectGetDto>>> GetProjects()
        {
            return Ok(await _projectService.GetProjects());
        }

        /// <summary>
        /// Get an individual project based on it's Id.
        /// </summary>
        /// <param name="id">The Id of the project.</param>
        /// <returns>The project with the corresponding Id.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectGetDto>> GetProjectById(int id)
        {
            return Ok(await _projectService.GetProjectById(id));
        }

        /// <summary>
        /// Create a new project.
        /// </summary>
        /// <param name="newProject">A new project object.</param>
        /// <returns></returns>
        [HttpPost("")]
        public ActionResult CreateProject(ProjectCreateDto newProject)
        {
            _projectService.CreateProject(newProject);
            return Ok();
        }

        /// <summary>
        /// Update an existing project.
        /// </summary>
        /// <param name="updatedProject">The project object containing the information used to update the existing project.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProjectById(ProjectUpdateDto updatedProject)
        {
            await _projectService.UpdateProject(updatedProject);
            return Ok();
        }

        /// <summary>
        /// Delete a project based on it's Id.
        /// </summary>
        /// <param name="id">The Id of the project.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProjectById(int id)
        {
            await _projectService.DeleteProject(id);
            return Ok();
        }
    }
}