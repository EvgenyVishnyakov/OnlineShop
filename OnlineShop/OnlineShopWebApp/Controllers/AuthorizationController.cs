using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.DTO;
using OnlineShopWebApp.Service;
using OnlineShopWebApp.ViewModels;

namespace OnlineShopWebApp.Controllers;

public class AuthorizationController : Controller
{
    private readonly AuthorizationService _authorizationService;
    private readonly SignInManager<User> _signInManager;
    private readonly UserService _userService;

    public AuthorizationController(AuthorizationService authorizationService, SignInManager<User> signInManager, UserService userService)
    {
        _authorizationService = authorizationService;
        _signInManager = signInManager;
        _userService = userService;
    }

    public IActionResult Login(string returnUrl)
    {

        return View(new LoginModelDTO() { ReturnUrl = returnUrl });
    }

    public ActionResult Registration(string returnUrl)
    {
        return View(new UserRegisterViewModel() { ReturnUrl = returnUrl });
    }

    [HttpPost]
    public async Task<IActionResult> RegistrationAsync([FromForm] UserRegisterViewModel userRegister)
    {
        var existingUser = await _authorizationService.GetUserAsync(userRegister);
        if (existingUser != null)
        {
            ModelState.AddModelError("", "Такой логин уже существует!");
        }
        if (ModelState.IsValid)
        {
            var newUser = await _authorizationService.CreateUserAsync(userRegister);
            var tempUserId = HttpContext.Session.GetString(Constants.SessionPerson);
            if (tempUserId != null)
                newUser.TransitionUserId = Guid.Parse(tempUserId);

            await _userService.UpdateAsync(newUser);

            if (userRegister.ReturnUrl == null)
                return Redirect("~/Home/Index");
            else
                return Redirect(userRegister.ReturnUrl);
        }
        return View(userRegister);
    }

    [HttpPost]
    public async Task<IActionResult> LoginAsync(LoginModelDTO loginModel)
    {
        var existingUser = await _authorizationService.GetUserByLoginAsync(loginModel);
        if (existingUser == null)
        {
            ModelState.AddModelError("", "Такой логин не существует! Пройдите регистрацию");
            return View(loginModel);
        }
        var tempUserId = HttpContext.Session.GetString(Constants.SessionPerson);
        if (tempUserId != null)
            existingUser.TransitionUserId = Guid.Parse(tempUserId);

        await _userService.UpdateAsync(existingUser);

        var singResult = await _signInManager.PasswordSignInAsync(existingUser, loginModel.Password, loginModel.RememberMe, false);

        if (singResult.Succeeded)
        {

            if (loginModel.ReturnUrl == null)
                return Redirect("~/Home/Index");
            else
            {
                return Redirect(loginModel.ReturnUrl);
            }
        }
        ModelState.AddModelError("", "Неверный пароль");
        return View(loginModel);
    }

    public async Task<IActionResult> LogoutAsync()
    {
        await _signInManager.SignOutAsync();
        HttpContext.Session.Remove(Constants.SessionPerson);
        return RedirectToAction("Index", "Home");
    }
}