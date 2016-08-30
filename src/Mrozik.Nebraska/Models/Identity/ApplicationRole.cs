using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Mrozik.Nebraska.Models.Identity
{
    public class ApplicationRole : IdentityRole<int>
    {
        public ApplicationRole()
        {
        }

        public ApplicationRole(string roleName)
        {
            Name = roleName;
        }
    }
}