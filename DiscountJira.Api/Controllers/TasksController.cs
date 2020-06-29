using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DiscountJira.Api.Dtos;
using DiscountJira.Core.Models;
using DiscountJira.Core.Services.ProjectService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
//using DiscountJira.Api.Models;

namespace DiscountJira.Api.Controllers
{
    [Route("projects/{projectId}/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        private readonly ITaskService _taskService;
        public TasksController(IProjectService projectService, ITaskService taskService, IMapper mapper, LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
            _mapper = mapper;
            _projectService = projectService;
            _taskService = taskService;
        }

        // POST api/task
        [HttpPost("")]
        public async Task<ActionResult<TaskItemDto>> CreateTask(int projectId, TaskItemDto newTaskItem)
        {
            var newTask = _mapper.Map<TaskItem>(newTaskItem);
            var project = await _projectService.GetProjectById(projectId, false);

            if (await _taskService.CreateTask(project, newTask))
            {
                var location = _linkGenerator.GetPathByAction("GetProjectById", "Projects", new { id = project.Id });
                return Created(location, _mapper.Map<ProjectDto>(newTask));
            }

            return BadRequest("Could not create that task.");
        }

        // PUT api/task/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int projectId, TaskItemDto updatedTask)
        {
            var project = await _projectService.GetProjectById(projectId, true);
            if (project == null)
                return NotFound("Project with that Id not found.");

            var oldTask = project.Tasks.Where(t => t.Id == updatedTask.Id).Single();
            if (oldTask == null)
                return NotFound("Task in the project with the specified Id not found.");

            if (await _taskService.UpdateTask(_mapper.Map<TaskItem>(oldTask), _mapper.Map<TaskItem>(updatedTask)))
                return Ok();

            return BadRequest("Could not delete that project.");
        }

        // DELETE api/task/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskById(int projectId, int id)
        {
            var project = await _projectService.GetProjectById(projectId, false);
            if (project == null)
                return NotFound("Project with that Id not found.");

            var task = project.Tasks.Where(t => t.Id == id).Single();
            if (task == null)
                return NotFound("Task in the project with the specified Id not found.");

            if (await _taskService.DeleteTask(task))
                return Ok();

            return BadRequest("Could not delete that task.");
        }
    }
}