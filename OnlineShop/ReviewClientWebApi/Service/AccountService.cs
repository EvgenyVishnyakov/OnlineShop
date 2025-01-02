using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;
using ReviewClientWebApi.Interfaces;
using ReviewClientWebApi.Models;

namespace ReviewClientWebApi.Service;

public class AccountService : IAccountService
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;

    public AccountService(SignInManager<User> signInManager, UserManager<User> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<bool> IsValidLoginAsync(Authorization user)
    {

        var result = await _signInManager.PasswordSignInAsync(user.Login, user.Password, true, false);

        return result.Succeeded;
    }

    public async Task<bool> IsValidUser(Registration registrationUser)
    {
        var excitingUser = await _userManager.FindByEmailAsync(registrationUser.Email);
        if (excitingUser == null)
        {
            var user = new User { UserName = registrationUser.Email, Email = registrationUser.Email, PhoneNumber = registrationUser.PhoneNumber };
            var result = await _userManager.CreateAsync(user, registrationUser.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Constants.UserRoleName);
            }

            return result.Succeeded;
        }
        else
            return false;
    }
}
