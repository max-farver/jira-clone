using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiscountJira.Core.Models
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
    public class TaskItem
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
        public IEnumerable<AppUser> AssignedMembers { get; set; }
        public bool isArchived { get; set; }
        public bool isDeleted { get; set; }
    }
}