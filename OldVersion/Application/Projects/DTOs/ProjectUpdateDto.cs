using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Users;

namespace Application.Projects.DTOs
{
    public class ProjectUpdateDto
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Version { get; set; }
        public List<User> Members { get; set; }
    }
}