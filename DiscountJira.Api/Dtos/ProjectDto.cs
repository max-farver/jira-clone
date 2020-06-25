using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiscountJira.Api.Dtos
{
    public class ProjectDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        public double Version { get; set; }
        public List<AppUserDto> Members { get; set; }
        public List<TaskItemDto> Tasks { get; set; }
        public AppUserDto Owner { get; set; }
    }
}