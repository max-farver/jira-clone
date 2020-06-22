using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
//using API.Models;

namespace API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        // GET api/project
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<string>>> Getstrings() {
            var projects = await _unitOfWork.Projects.GetAll();
            return Ok(projects);
        }

        // GET api/project/5
        [HttpGet("{id}")]
        public ActionResult<string> GetstringById(int id) {
            return null;
        }

        // POST api/project
        [HttpPost("")]
        public void Poststring(string value) { }

        // PUT api/project/5
        [HttpPut("{id}")]
        public void Putstring(int id, string value) { }

        // DELETE api/project/5
        [HttpDelete("{id}")]
        public void DeletestringById(int id) { }
    }
}