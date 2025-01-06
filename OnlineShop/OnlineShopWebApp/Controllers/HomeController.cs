using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Service;

namespace OnlineShopWebApp.Controllers;

public class HomeController : Controller
{
    const string SessionPerson = "TempPerson";

    private readonly ProductService _productService;

    public HomeController(ProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> IndexAsync()
    {
        var name = User.Identity.Name;
        if (name != null)
        {
            var products = await _productService.GetAllAsync();
            var productsVM = Mapping.ToProductViewModels(products);
            return View(productsVM);
        }
        else
        {
            var value = HttpContext.Session.GetString(SessionPerson);
            if (value == null)
            {
                var user = new User();
                HttpContext.Session.SetString(SessionPerson, user.TransitionUserId.ToString());
            }
            var products = await _productService.GetAllAsync();
            var productsVM = Mapping.ToProductViewModels(products);
            return View(productsVM);
        }
    }

    public IActionResult Contacts()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
