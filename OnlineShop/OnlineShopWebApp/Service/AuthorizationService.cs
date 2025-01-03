using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;
using OnlineShopWebApp.DTO;
using OnlineShopWebApp.ViewModels;
using Serilog;

namespace OnlineShopWebApp.Service;

public class AuthorizationService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly string imagePath = "/Images/Пустая_аватарка.png";

    public AuthorizationService(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<User?> GetUserAsync(UserRegisterViewModel newUser)
    {
        return await _userManager.FindByNameAsync(newUser.Login);
    }

    public async Task<User?> GetUserByLoginAsync(LoginModelDTO login)
    {
        return await _userManager.FindByNameAsync(login.Login);
    }

    public async Task<User> CreateUserAsync(UserRegisterViewModel newUser)
    {
        var user = new User
        {
            Email = newUser.Login,
            UserName = newUser.Login,
            PhoneNumber = newUser.PhoneNumber,
            ProfileImage = imagePath
        };
        var result = await _userManager.CreateAsync(user, newUser.Password);
        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, false);
            await TryAssignUserRoleAsync(user);
            return user;
        }

        return null;
    }

    private async Task TryAssignUserRoleAsync(User user)
    {
        try
        {
            await _userManager.AddToRoleAsync(user, Constants.UserRoleName);
            Log.Information($"Пользователю {user.UserName} предоставлены права доступа");
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Ошибка добавления роли");
        }
    }
}
