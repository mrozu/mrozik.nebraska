using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Identity;
using Mrozik.Nebraska.Models;
using Mrozik.Nebraska.Models.Identity;

namespace Mrozik.Nebraska.Data
{
    public class DefaultUsersAndRolesInitializer : IAsyncStartable
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public DefaultUsersAndRolesInitializer(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task StartAsync()
        {
            var administratorRole = await CreateRoleIfNotExists(ApplicationRoles.Administrator);
            await AddClaimToRoleIfNotExists(administratorRole, ApplicationClaims.CanRegisterNewUser);
            await CreateRoleIfNotExists(ApplicationRoles.SimpleUser);
            await CreateRoleIfNotExists(ApplicationRoles.Role2);
            await CreateRoleIfNotExists(ApplicationRoles.Role3);

            var admin = await CreateUserIfNotExist("admin", "g@m.com", "12");
            await AssignToRole(admin, ApplicationRoles.Administrator);

            var simpleUser = await CreateUserIfNotExist("user", "g@m.com", "12");
            await AssignToRole(simpleUser, ApplicationRoles.SimpleUser);

        }

        private async Task AddClaimToRoleIfNotExists(ApplicationRole role, string claimType)
        {
            var claims = await _roleManager.GetClaimsAsync(role);
            if (claims.All(c => c.Type != claimType))
            {
                var result = await _roleManager.AddClaimAsync(role, new Claim(claimType, ""));
                if (!result.Succeeded)
                    throw new InvalidOperationException($"Error while adding claim  of type {claimType} to role: {role.Name}. Details: {result}");
            }
        }

        private async Task AssignToRole(ApplicationUser user, string roleName)
        {
            var result = await _userManager.AddToRoleAsync(user, roleName);
            if (!result.Succeeded)
                throw new InvalidOperationException($"Error while assinging user: {user.UserName} to {roleName} role. Details: {result}");
        }

        private async Task<ApplicationUser> CreateUserIfNotExist(string username, string email, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
                return user;

            user = new ApplicationUser { UserName = username, Email = email };
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
                throw new InvalidOperationException($"Error while creating user: {username}. Details: {result}");

            return user;
        }

        private async Task<ApplicationRole> CreateRoleIfNotExists(string roleName)
        {
            var applicationRole = await _roleManager.FindByNameAsync(roleName);
            if (applicationRole == null)
            {
                applicationRole = new ApplicationRole(roleName);
                var result = await _roleManager.CreateAsync(applicationRole);
                if (!result.Succeeded)
                    throw new InvalidOperationException($"Error while creating role {roleName}. Details: {result}");
            }
            return applicationRole;
        }

    }
}