using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Service;
using OnlineShopWebApp.ViewModels;

namespace OnlineShopWebApp.Areas.Admin.Controllers;

[Area(Constants.AdminRoleName)]
[Authorize(Roles = Constants.AdminRoleName)]
public class UserManagmentController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly UserService _userService;


    public UserManagmentController(UserManager<User> userManager, UserService userService)
    {
        _userManager = userManager;
        _userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        var usersQuery = await _userManager.Users.ToListAsync();
        return View(usersQuery.Select(Mapping.ToUserVM).ToList());
    }

    public IActionResult Add()
    {
        return View();
    }

    public async Task<IActionResult> Detail(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        return View(Mapping.ToUserVM(user));
    }

    [HttpPost]
    public async Task<IActionResult> Add(UserVM userVM)
    {
        var existingUser = await _userService.GetUserAsync(userVM);
        if (existingUser != null)
        {
            ModelState.AddModelError("", "Такой логин уже существует!");
        }
        if (ModelState.IsValid)
        {
            var user = await _userService.CreateUserAsync(userVM);
            var result = await _userManager.CreateAsync(user, userVM.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
        }

        return View(userVM);
    }

    public async Task<IActionResult> Delete(string userId)
    {
        await _userService.DeleteAsync(userId);
        return Redirect(nameof(Index));
    }

    public async Task<IActionResult> EditAsync(string userId)
    {
        var userVM = await _userService.EditAsync(userId);
        return View(userVM);
    }

    public async Task<IActionResult> EditPassword(string userId)
    {

        var userVM = await _userService.EditPasswordAsync(userId);
        return View(userVM);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UserWithOutPasswordVM model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user != null)
            {
                user = Mapping.ToUserModel(user, model);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
        }
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> ChangePassword(UserChangePasswordVM model)
    {
        if (model.Email == model.Password)
        {
            ModelState.AddModelError("", "Пароль и логин не должны совпадать!");
        }

        if (ModelState.IsValid)
        {
            await _userService.ChangePasswordAsync(model);
            return RedirectToAction(nameof(Index));
        }
        return RedirectToAction(nameof(EditPassword));
    }

    public async Task<IActionResult> EditRights(string userId)
    {
        var model = await _userService.EditRightsAsync(userId);
        return base.View(model);
    }

    [HttpPost]
    public async Task<IActionResult> EditRights(string userId, Dictionary<string, bool> userRoles)
    {
        await _userService.EditRightsAsync(userId, userRoles);
        return RedirectToAction("Detail", new { userId });
    }
}
