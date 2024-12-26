using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Db.Models;

public class IdentityInitializer
{
    public static void Initialize(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        var adminEmail = "vis-evgenij@yandex.ru";
        var password = "_Aa12345678";
        var phoneNumber = "89159568409";
        var profileImage = "/Images/Пустая_аватарка.png";

        if (roleManager.FindByNameAsync(Constants.AdminRoleName).Result == null)
        {
            roleManager.CreateAsync(new IdentityRole(Constants.AdminRoleName)).Wait();
        }
        if (roleManager.FindByNameAsync(Constants.UserRoleName).Result == null)
        {
            roleManager.CreateAsync(new IdentityRole(Constants.UserRoleName)).Wait();
        }
        if (userManager.FindByNameAsync(adminEmail).Result == null)
        {
            var admin = new User { Email = adminEmail, UserName = adminEmail, PhoneNumber = phoneNumber, ProfileImage = profileImage };
            var result = userManager.CreateAsync(admin, password).Result;
            if (result.Succeeded)
            {
                userManager.SetPhoneNumberAsync(admin, phoneNumber).Wait();
                userManager.AddToRoleAsync(admin, Constants.AdminRoleName).Wait();
            }
        }
    }
}
