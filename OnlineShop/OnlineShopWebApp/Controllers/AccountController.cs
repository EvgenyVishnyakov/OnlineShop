using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Service;
using OnlineShopWebApp.ViewModels;

namespace OnlineShopWebApp.Controllers;

public class AccountController : Controller
{
    private readonly SignInManager<User> _signInManager;
    private readonly AccountService _accountService;
    private readonly UserService _userService;
    private readonly UserManager<User> _userManager;

    public AccountController(SignInManager<User> signInManager, AccountService accountService, UserService userService, UserManager<User> userManager)
    {
        _signInManager = signInManager;
        _accountService = accountService;
        _userService = userService;
        _userManager = userManager;

    }

    public async Task<IActionResult> IndexAsync(string userLogin)
    {
        var accountVM = await _accountService.GetUserAsync(userLogin);
        return View(accountVM);
    }

    public async Task<IActionResult> EditAsync(string userId)
    {
        var userVM = await _userService.EditAsync(userId);
        return View(userVM);
    }

    public async Task<IActionResult> EditPasswordAsync(string userId)
    {

        var userVM = await _userService.EditPasswordAsync(userId);
        return View(userVM);
    }

    [HttpPost]
    public async Task<IActionResult> EditAsync(UserWithOutPasswordVM model)
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
                    return RedirectToAction("Index", new { userLogin = user.Email });
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
    public async Task<IActionResult> ChangePasswordAsync(UserChangePasswordVM model)
    {
        if (model.Email == model.Password)
        {
            ModelState.AddModelError("", "Пароль и логин не должны совпадать!");
        }

        if (ModelState.IsValid)
        {
            await _userService.ChangePasswordAsync(model);
            return RedirectToAction("Index", new { userLogin = model.Email });
        }
        return RedirectToAction(nameof(EditPasswordAsync));
    }

    public async Task<IActionResult> EditProfileAsync(string userId)
    {
        var userVM = await _accountService.EditAsync(userId);
        return View(userVM);
    }

    [HttpPost]
    public async Task<IActionResult> EditProfileAsync(EditProfileViewModel modelVM)
    {
        if (ModelState.IsValid)
        {
            if (modelVM.UploadedFile != null)
            {
                var userDb = await _accountService.EditProfileAsync(modelVM);
                var result = await _userManager.UpdateAsync(userDb);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", new { userLogin = userDb.Email });
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            else
                return RedirectToAction("Index", new { userLogin = modelVM.Login });
        }
        return View(modelVM);
    }

    public async Task<IActionResult> GetOrderAsync(string userLogin)
    {
        var ordersVM = await _accountService.GetOrdersAsync(userLogin);
        return View("OrderAccount", ordersVM);
    }

    public async Task<IActionResult> SingOutAsync()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> DeleteAsync(EditProfileViewModel modelVM)
    {
        if (ModelState.IsValid)
        {
            var userDb = await _accountService.DeleteAsync(modelVM);
            var result = await _userManager.UpdateAsync(userDb);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", new { userLogin = userDb.Email });
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
        }
        return View(modelVM);
    }
}
