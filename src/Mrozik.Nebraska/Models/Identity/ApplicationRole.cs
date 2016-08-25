using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Mrozik.Nebraska.Models.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        {
        }

        public ApplicationRole(string roleName) : base(roleName)
        {
        }
    }
}