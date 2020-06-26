using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DiscountJira.Api.Dtos;
using DiscountJira.Core.Models;
using DiscountJira.Core.Services.ProjectService;
using Microsoft.AspNetCore.Mvc;

namespace DiscountJira.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SummaryController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;
        public SummaryController(IProjectService projectService, IMapper mapper)
        {
            _mapper = mapper;
            _projectService = projectService;
        }

        // GET api/summary
        [HttpGet("")]
        public async Task<ActionResult<UserSummaryDto>> GetSummary()
        {
            var projects = await _projectService.GetProjects();
            IEnumerable<TaskItem> tasks = new List<TaskItem>();

            foreach (var project in projects)
            {
                tasks = tasks.Concat(project.Tasks ?? new List<TaskItem>());
            }

            // Filter by user here
            // tasks = tasks.Where(t => t.AssignedMembers.Contains("user"));
            return Ok(new UserSummaryDto { Projects = _mapper.Map<IEnumerable<ProjectSummaryDto>>(projects), UserTasks = _mapper.Map<IEnumerable<TaskItemDto>>(tasks) });
        }
    }
}