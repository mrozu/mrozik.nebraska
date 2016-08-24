using System;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Identity;
using Mrozik.Nebraska.Models;

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
            await CreateRoleIfNotExists(ApplicationRoles.Administrator);
            await CreateRoleIfNotExists(ApplicationRoles.Role1);
            await CreateRoleIfNotExists(ApplicationRoles.Role2);
            await CreateRoleIfNotExists(ApplicationRoles.Role3);

            await CreateAdminUserIfNotExist("admin");
        }

        private async Task CreateAdminUserIfNotExist(string username)
        {
            if (await _userManager.FindByNameAsync(username) == null)
            {
                var adminUser = CreateAdminUser(username);
                var result = await _userManager.CreateAsync(adminUser, "Mrozu12!");
                if (!result.Succeeded)
                    throw new InvalidOperationException(
                        $"Error while creating user: {adminUser.UserName}. Details: {result}");

                result = await _userManager.AddToRoleAsync(adminUser, ApplicationRoles.Administrator);
                if (!result.Succeeded)
                    throw new InvalidOperationException(
                        $"Error while assinging user: {adminUser.UserName} to {ApplicationRoles.Administrator} role. Details: {result}");
            }
        }

        private static ApplicationUser CreateAdminUser(string username)
        {
            return new ApplicationUser
            {
                UserName = username,
                Email = "g@m.com"
            };
        }

        private async Task CreateRoleIfNotExists(string roleName)
        {
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                var result = await _roleManager.CreateAsync(new ApplicationRole(roleName));
                if (!result.Succeeded)
                    throw new InvalidOperationException(
                        $"Error while creating role {roleName}. Details: {string.Join(" ", result.Errors.SelectMany(e => e.Description))}");
            }
        }
    }
}