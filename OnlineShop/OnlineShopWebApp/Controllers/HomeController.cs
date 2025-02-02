using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Redis;
using OnlineShopWebApp.Service;
using OnlineShopWebApp.ViewModels;

namespace OnlineShopWebApp.Controllers;

public class HomeController : Controller
{
    const string SessionPerson = "TempPerson";

    private readonly ProductService _productService;
    private readonly RedisCacheService _redisCacheService;

    public HomeController(ProductService productService, RedisCacheService redisCacheService)
    {
        _productService = productService;
        _redisCacheService = redisCacheService;
    }

    public async Task<IActionResult> IndexAsync()
    {
        var name = User.Identity?.Name;
        var cacheProducts = await _redisCacheService.TryGetAsync(Constants.RedisCacheKey);
        List<ProductViewModel> productsVM;

        if (!cacheProducts.IsNullOrEmpty())
        {
            if (name == null)
            {
                var value = HttpContext.Session.GetString(SessionPerson);
                if (value == null)
                {
                    var user = new User();
                    HttpContext.Session.SetString(SessionPerson, user.TransitionUserId.ToString());
                }
            }

            productsVM = JsonSerializer.Deserialize<List<ProductViewModel>>(cacheProducts)!;
        }
        else
        {
            if (name == null)
            {
                var value = HttpContext.Session.GetString(SessionPerson);
                if (value == null)
                {
                    var user = new User();
                    HttpContext.Session.SetString(SessionPerson, user.TransitionUserId.ToString());
                }
            }

            var products = await _productService.GetAllAsync();
            productsVM = Mapping.ToProductViewModels(products);
            //return View(productsVM);
            var productsJson = JsonSerializer.Serialize(productsVM);
            await _redisCacheService.SetAsync(Constants.RedisCacheKey, productsJson);
        }
        return View(productsVM);
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
