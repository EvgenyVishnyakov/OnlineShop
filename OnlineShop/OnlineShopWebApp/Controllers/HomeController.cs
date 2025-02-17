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
using X.PagedList.Extensions;

namespace OnlineShopWebApp.Controllers;

public class HomeController : Controller
{
    private readonly ProductService _productService;
    private readonly RedisCacheService _redisCacheService;

    public HomeController(ProductService productService, RedisCacheService redisCacheService)
    {
        _productService = productService;
        _redisCacheService = redisCacheService;
    }

    public async Task<IActionResult> IndexAsync(string searchString, int? page)
    {
        var pageNumber = page ?? 1;
        var pageSize = 2;
        ViewBag.SearchString = searchString;

        var name = User.Identity?.Name;
        var cacheProducts = await _redisCacheService.TryGetAsync(Constants.RedisCacheKey);
        List<ProductViewModel> productsVM;

        if (!cacheProducts.IsNullOrEmpty())
        {
            if (name == null)
            {
                var value = HttpContext.Session.GetString(Constants.SessionPerson);
                if (value == null)
                {
                    var user = new User();
                    HttpContext.Session.SetString(Constants.SessionPerson, user.TransitionUserId.ToString());
                }
            }

            productsVM = JsonSerializer.Deserialize<List<ProductViewModel>>(cacheProducts)!;
            var productListPaggin = productsVM.ToPagedList(pageNumber, pageSize);
            return View(productListPaggin);
        }
        else
        {
            if (name == null)
            {
                var value = HttpContext.Session.GetString(Constants.SessionPerson);
                if (value == null)
                {
                    var user = new User();
                    HttpContext.Session.SetString(Constants.SessionPerson, user.TransitionUserId.ToString());
                }
            }

            var products = await _productService.GetAllAsync();
            productsVM = Mapping.ToProductViewModels(products);
            var productsJson = JsonSerializer.Serialize(productsVM);
            await _redisCacheService.SetAsync(Constants.RedisCacheKey, productsJson);
            var productListPaggin = productsVM.ToPagedList(pageNumber, pageSize);
            return View(productListPaggin);
        }
        //return View(productsVM);
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
