using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain;

namespace Application.Projects.DTOs
{
    public class ProjectCreateDto
    {

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public double Version { get; set; }
        public List<User> Members { get; set; }
    }
}