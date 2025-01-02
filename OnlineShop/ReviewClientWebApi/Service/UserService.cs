using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;
using Serilog;

namespace ReviewClientWebApi.Service;

public class UserService
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserService(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<User?> GetUserAsync(User newUser)
    {
        return await _userManager.FindByNameAsync(newUser.UserName);
    }

    public async Task<User> CreateUserAsync(User newUser)
    {
        var user = new User
        {
            Email = newUser.Email,
            PhoneNumber = newUser.PhoneNumber,
            UserName = newUser.UserName,
            ProfileImage = "/Images/Пустая_аватарка.png"
        };
        await TryAssignUserRoleAsync(user);
        return user;
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

    public async Task DeleteAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            IdentityResult result = await _userManager.DeleteAsync(user);
        }
    }
}
