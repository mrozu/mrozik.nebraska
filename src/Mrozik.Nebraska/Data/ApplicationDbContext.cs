using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mrozik.Nebraska.Models.Identity;

namespace Mrozik.Nebraska.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().ToTable("Users", "dbo");
            builder.Entity<ApplicationRole>().ToTable("Roles", "dbo");
            builder.Entity<IdentityUserRole<int>>().ToTable("UserRoles", "dbo");
            builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins", "dbo");
            builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims", "dbo");
            builder.Entity<IdentityUserToken<int>>().ToTable("UserTokens", "dbo");
            builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims", "dbo");

        }
    }
}
