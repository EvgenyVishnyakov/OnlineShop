using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.DTO;
using OnlineShopWebApp.Service;
using OnlineShopWebApp.ViewModels;

namespace OnlineShopWebApp.Controllers;

public class AuthorizationController : Controller
{
    const string SessionPerson = "TempPerson";
    private readonly AuthorizationService _authorizationService;
    private readonly SignInManager<User> _signInManager;

    public AuthorizationController(AuthorizationService authorizationService, SignInManager<User> signInManager)
    {
        _authorizationService = authorizationService;
        _signInManager = signInManager;
    }

    public IActionResult Login(string returnUrl)
    {

        return View(new LoginModelDTO() { ReturnUrl = returnUrl });
    }

    public IActionResult Registration(string returnUrl)
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
            if (userRegister.ReturnUrl == null)
                return Redirect("Login");
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
        var tempUserId = HttpContext.Session.GetString(SessionPerson);
        //HttpContext.Session.Remove(SessionPerson);       



        var singResult = await _signInManager.PasswordSignInAsync(existingUser, loginModel.Password, loginModel.RememberMe, false);
        //SessionPerson = singResult.ToString();
        HttpContext.Session.SetString(singResult.ToString(), tempUserId);

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
        return RedirectToAction("Index", "Home");
    }
}
//public static class SessionExtensions
//{
//    public static void SetObject(this ISession session, string key, object value)
//    {
//        session.SetString(key, JsonConvert.SerializeObject(value));
//    }

//    public static T GetObject<T>(this ISession session, string key)
//    {
//        var value = session.GetString(key);
//        return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
//    }
//}