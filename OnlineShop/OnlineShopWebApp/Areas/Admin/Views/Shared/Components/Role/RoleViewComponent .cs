using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.ViewModels;

namespace OnlineShopWebApp.Areas.Admin.Views.Shared.Component.Role
{
    public class RoleViewComponent : ViewComponent
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleViewComponent(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var userRoles = await _userManager.GetRolesAsync(user);
            var roles = _roleManager.Roles.ToList();
            var model = new RoleViewModel
            {
                UserRoles = userRoles.Select(x => new RoleViewModel { Name = x }).ToList(),

            };
            return base.View(model);
        }
    }
}
