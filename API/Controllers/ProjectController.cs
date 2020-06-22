using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Projects.DTOs;
using Application.Projects.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    public class ProjectController : BaseController {

        // GET api/project
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ProjectGetDto>>> GetProjects() {
            return Ok(await Mediator.Send(new GetProjects.Query()));
        }

        // GET api/project/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectGetDto>> GetProjectById(int id) {
            return Ok(await Mediator.Send(new GetProjectById.Query { Id = id }));
        }

        // POST api/project
        [HttpPost("")]
        public async void CreateProject(ProjectCreateDto newProject) {
            // TODO
        }

        // PUT api/project/5
        [HttpPut("{id}")]
        public void UpdateProjectById(int id, string value) { }

        // DELETE api/project/5
        [HttpDelete("{id}")]
        public void DeleteProjectById(int id) { }
    }
}