using Microsoft.AspNetCore.Mvc;
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

    public async Task<IActionResult> FindNameAsync(string name)
    {
        var product = await _productService.GetAsync(name);
        if (product != null)
            return RedirectToAction("Index", new { productId = product.Id });
        return Redirect("~/Home/Index");
    }
}
