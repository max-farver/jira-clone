using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Users;

namespace Domain.Projects
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public double Version { get; set; }
        public List<User> Members { get; set; }
        public bool isArchived { get; set; }
        public bool isDeleted { get; set; }
    }
}