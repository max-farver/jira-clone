using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiscountJira.Api.Dtos
{
    public enum Status
    {
        Backlog,
        Planned,
        Development,
        NeedsTesting,
        Testing,
        ToDeploy,
        Deployed
    }
    public class TaskItemDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        public DateTime EstimatedTime { get; set; }
        [Required]
        public Status Status { get; set; }
        public List<AppUserDto> AssignedMembers { get; set; }
    }
}