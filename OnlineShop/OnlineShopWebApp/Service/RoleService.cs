using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShopWebApp.ViewModels;

namespace OnlineShopWebApp.Service;

public class RoleService
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleService(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<List<RoleVM>> GetAllAsync()
    {
        var roles = await _roleManager.Roles.ToListAsync();
        return roles.Select(x => new RoleVM() { Name = x.Name }).ToList();
    }

    public async Task RemoveAsync(string roleName)
    {
        var existingRole = await _roleManager.FindByNameAsync(roleName);
        await _roleManager.DeleteAsync(existingRole);
    }
}