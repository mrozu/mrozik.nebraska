using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Mrozik.Nebraska.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        {
        }

        public ApplicationRole(string roleName) : base(roleName)
        {
        }
    }

    public static class ApplicationRoles
    {
        public static readonly string Administrator = "Administrator";
        public static readonly string Role1 = "Role1";
        public static readonly string Role2 = "Role2";
        public static readonly string Role3 = "Role3";
    }
}
