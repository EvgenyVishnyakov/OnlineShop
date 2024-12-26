using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApi.Service;
using OnlineShopWebApp.Areas.Admin.Models;

namespace OnlineShopWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class RoleManagmentController : Controller
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly RoleService _roleService;

    public RoleManagmentController(RoleManager<IdentityRole> roleManager, RoleService roleService)
    {
        _roleManager = roleManager;
        _roleService = roleService;
    }

    [HttpGet("GetRoles")]
    public async Task<IActionResult> Index()
    {
        var roles = await _roleService.GetAllAsync();
        if (roles.Count != 0)
            return Ok(roles);
        return BadRequest("Ролей нет");
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add(Role role)
    {
        var result = await _roleManager.CreateAsync(new IdentityRole(role.Name));
        if (result != null)
            return Ok(result);
        return BadRequest($"Ошибка в добавлении роли {role.Name}");
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Remove(string roleName)
    {
        await _roleService.RemoveAsync(roleName);
        return Ok();
    }
}
