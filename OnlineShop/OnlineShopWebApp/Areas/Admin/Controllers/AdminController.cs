using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers;

[Area(Constants.AdminRoleName)]
[Authorize(Roles = Constants.AdminRoleName)]
public class AdminController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
