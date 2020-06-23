using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain.Users
{
    public class User : IdentityUser
    {
        public string DisplayName { get; set; }
        public string AvatarLocation { get; set; }
        public bool isDeleted { get; set; }

    }
}