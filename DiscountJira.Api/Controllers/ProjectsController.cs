using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscountJira.Api.Dtos;
using DiscountJira.Core.Services.ProjectService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Microsoft.AspNetCore.Routing;
using DiscountJira.Core.Models;

namespace DiscountJira.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        public ProjectsController(IProjectService projectService, IMapper mapper, LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
            _mapper = mapper;
            _projectService = projectService;

        }
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetProjects(bool includeTasks = false)
        {
            var results = await _projectService.GetProjects(includeTasks);
            return Ok(_mapper.Map<IEnumerable<ProjectDto>>(results));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDto>> GetProjectById(int id, bool includeTasks = false)
        {
            var project = await _projectService.GetProjectById(id, includeTasks);
            if (project == null)
                return NotFound("Project with that Id not found.");

            return Ok(_mapper.Map<ProjectDto>(project));
        }

        [HttpPost("")]
        public async Task<ActionResult<ProjectDto>> CreateProject(ProjectDto newProjectDto)
        {
            var newProject = _mapper.Map<Project>(newProjectDto);
            if (await _projectService.CreateProject(newProject))
            {
                var location = _linkGenerator.GetPathByAction("GetProjectById", "Projects", new { id = newProject.Id });
                return Created(location, _mapper.Map<ProjectDto>(newProject));
            }
            return BadRequest("Could not create that project.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var project = await _projectService.GetProjectById(id, false);
            if (project == null)
                return NotFound("Project with that Id not found.");

            if (await _projectService.DeleteProject(project))
                return Ok();
            return BadRequest("Could not delete that project.");
        }


    }
}
