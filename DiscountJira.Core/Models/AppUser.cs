using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiscountJira.Core.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        [Required]
        public string DisplayName { get; set; }
        public string AvatarLocation { get; set; }
        public bool isDeleted { get; set; }
    }
}