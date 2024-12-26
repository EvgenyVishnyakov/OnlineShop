using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShopWebApp.Areas.Admin.Models;

namespace OnlineShopWebApi.Service;

public class RoleService
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleService(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<List<Role>> GetAllAsync()
    {
        var roles = await _roleManager.Roles.ToListAsync();
        return roles.Select(static x => new Role() { Name = x.Name }).ToList();
    }

    public async Task RemoveAsync(string roleName)
    {
        var existingRole = await _roleManager.FindByNameAsync(roleName);
        await _roleManager.DeleteAsync(existingRole);
    }
}