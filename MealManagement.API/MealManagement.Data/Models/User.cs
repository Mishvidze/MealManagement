using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealManagement.Data.Models
{
    public class User : IdentityUser<int>
    {
        public string Cucka { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
