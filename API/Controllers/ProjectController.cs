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

        // GET api/project
        /// <summary>
        /// Get a list of projects.
        /// </summary>
        /// <returns>A list of all projects.</returns>
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ProjectGetDto>>> GetProjects()
        {
            return Ok(await _projectService.GetProjects());
        }

        // GET api/project/5
        /// <summary>
        /// Get an individual project based on it's Id.
        /// </summary>
        /// <param name="id">The Id of the project.</param>
        /// <returns>The project with the corresponding Id.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectGetDto>> GetProjectById(int id)
        {
            var project = await _projectService.GetProjectById(id);
            if (project == null)
                return NotFound();

            return Ok();
        }

        // POST api/project
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

        // PUT api/project/5
        /// <summary>
        /// Update an existing project.
        /// </summary>
        /// <param name="updatedProject">The project object containing the information used to update the existing project.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult UpdateProjectById(ProjectUpdateDto updatedProject)
        {
            _projectService.UpdateProject(updatedProject);
            return Ok();
        }

        // DELETE api/project/5
        /// <summary>
        /// Delete a project based on it's Id.
        /// </summary>
        /// <param name="id">The Id of the project.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult DeleteProjectById(int id)
        {
            _projectService.DeleteProject(id);
            return Ok();
        }
    }
}