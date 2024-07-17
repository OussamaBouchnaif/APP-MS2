using Admin.Models;
using Microsoft.AspNetCore.Identity;

public static class RoleInitializer
{
    //public static async Task CreateRoles(IServiceProvider serviceProvider)
    //{
    //    var rolesManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
    //    var roles = Role.Roles;

    //    foreach (var roleName in roles)
    //    {
    //        var roleExists = await rolesManager.RoleExistsAsync(roleName);
    //        if (!roleExists)
    //        {
    //            await rolesManager.CreateAsync(new Role { Name = roleName });
    //        }
    //    }
    //}
}