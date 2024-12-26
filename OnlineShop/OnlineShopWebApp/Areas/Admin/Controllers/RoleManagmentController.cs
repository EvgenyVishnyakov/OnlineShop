using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Service;
using OnlineShopWebApp.ViewModels;

namespace OnlineShopWebApp.Areas.Admin.Controllers;

[Area(Constants.AdminRoleName)]
[Authorize(Roles = Constants.AdminRoleName)]
public class RoleManagmentController : Controller
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly RoleService _roleService;

    public RoleManagmentController(RoleManager<IdentityRole> roleManager, RoleService roleService)
    {
        _roleManager = roleManager;
        _roleService = roleService;
    }

    public async Task<IActionResult> Index()
    {
        var rolesVM = await _roleService.GetAllAsync();
        return View(rolesVM);
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(RoleVM roleVM)
    {
        if (await _roleManager.FindByNameAsync(roleVM.Name) != null)
        {
            ModelState.AddModelError("", "Такая роль уже существует!");
        }
        if (ModelState.IsValid)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole(roleVM.Name));
            if (result.Succeeded)
                return RedirectToAction("Index");
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
        }
        return View(roleVM);
    }

    public async Task<IActionResult> Remove(string roleName)
    {
        await _roleService.RemoveAsync(roleName);
        return RedirectToAction(nameof(Index));

    }
}
