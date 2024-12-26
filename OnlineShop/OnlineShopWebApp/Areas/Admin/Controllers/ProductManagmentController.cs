using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Service;
using OnlineShopWebApp.ViewModels;

namespace OnlineShopWebApp.Areas.Admin.Controllers;

[Area(Constants.AdminRoleName)]
[Authorize(Roles = Constants.AdminRoleName)]
public class ProductManagmentController : Controller
{
    private readonly ProductService _productService;

    public ProductManagmentController(ProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        var productsVm = await _productService.GetAllProductVmAsync();
        return View(productsVm);
    }

    public IActionResult GetProduct()
    {
        return View();
    }

    public async Task<IActionResult> Edit(Guid productId)
    {
        var productVM = await _productService.ToEditProductViewModelAsync(productId);
        return View(productVM);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromForm] CreateProductViewModel productVM)
    {
        if (ModelState.IsValid)
        {
            await _productService.CreateProductAsync(productVM);
            return RedirectToAction(nameof(Index));
        }
        else
        {
            return Redirect(nameof(Index));
        }
    }

    [HttpPost]
    public async Task<IActionResult> UpdateProduct([FromForm] EditProductViewModel productVM)
    {
        if (ModelState.IsValid)
        {
            await _productService.EditAsync(productVM);
            return RedirectToAction(nameof(Index));
        }
        else
        {
            return Redirect(nameof(Index));
        }
    }

    public async Task<IActionResult> Delete(Guid productId)
    {
        await _productService.DeleteAsync(productId);
        return RedirectToAction(nameof(Index));
    }
}
