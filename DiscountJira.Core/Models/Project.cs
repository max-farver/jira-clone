using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DiscountJira.Core.Models;

namespace DiscountJira.Core.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public double Version { get; set; }
        public IEnumerable<AppUser> Members { get; set; }
        public IEnumerable<TaskItem> Tasks { get; set; }
        public bool isArchived { get; set; }
        public bool isDeleted { get; set; }
    }
}