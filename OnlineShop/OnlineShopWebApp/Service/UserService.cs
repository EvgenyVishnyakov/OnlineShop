using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.ViewModels;
using Serilog;

namespace OnlineShopWebApp.Service;

public class UserService
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IUserRepository _userRepository;

    public UserService(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, IUserRepository userRepository)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _userRepository = userRepository;
    }

    public async Task<User?> GetUserAsync(UserVM newUser)
    {
        return await _userManager.FindByNameAsync(newUser.Login);
    }

    public async Task<User> CreateUserAsync(UserVM newUser)
    {
        var user = new User
        {
            Email = newUser.Login,
            PhoneNumber = newUser.PhoneNumber,
            UserName = newUser.Login,
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

    public async Task<UserWithOutPasswordVM> EditAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        var userVM = Mapping.ToUserWithOutPasswordVM(user);
        return userVM;
    }

    public async Task<UserChangePasswordVM> EditPasswordAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        var userVM = Mapping.ToUserChangePasswordVM(user);
        return userVM;
    }

    public async Task ChangePasswordAsync(UserChangePasswordVM model)
    {
        var user = await _userManager.FindByIdAsync(model.UserId);
        var newHashPassword = _userManager.PasswordHasher.HashPassword(user, model.Password);
        user.PasswordHash = newHashPassword;
        await _userManager.UpdateAsync(user);
    }

    public async Task<EditRightsVM> EditRightsAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        var userRoles = await _userManager.GetRolesAsync(user);
        var roles = await _roleManager.Roles.ToListAsync();
        var model = new EditRightsVM
        {
            UserId = user.Id,
            UserName = user.UserName,
            UserRoles = userRoles.Select(x => new RoleViewModel { Name = x }).ToList(),
            AllRoles = roles.Select(x => new RoleViewModel { Name = x.Name }).ToList()
        };

        return model;
    }

    public async Task EditRightsAsync(string userId, Dictionary<string, bool> userRoles)
    {
        var userCurrentRoles = userRoles.Select(x => x.Key);
        var user = await _userManager.FindByIdAsync(userId);
        var userRole = await _userManager.GetRolesAsync(user);

        await _userManager.RemoveFromRolesAsync(user, userRole);
        await _userManager.AddToRolesAsync(user, userCurrentRoles);
    }

    public async Task UpdateAsync(User user)
    {
        await _userRepository.UpdateAsync(user);
    }
}
