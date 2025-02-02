using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineShopWebApp.Service;

namespace OnlineShopWebApp.Controllers;

public class ProductController : Controller
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> IndexAsync(Guid productId)
    {
        var productVM = await _productService.ToProductVMAsync(productId);
        return View(productVM);
    }

    public async Task<IActionResult> FindProductAsync(string searchQuery, int? page)
    {
        var pageNumber = page ?? 1;
        var pageSize = 2;

        if (searchQuery.IsNullOrEmpty())
            return Redirect("~/Home/Index");
        else
        {
            var product = await _productService.GetAsync(searchQuery);
            if (product != null)
            {
                //ViewBag.SearchString = searchQuery;
                //var productsPaggin = product.ToPagedList(pageNumber, pageSize)// добавить при переходе на список
                return RedirectToAction("Index", new { productId = product.Id });
            }

            return Redirect("~/Home/Index");
        }
    }
}
