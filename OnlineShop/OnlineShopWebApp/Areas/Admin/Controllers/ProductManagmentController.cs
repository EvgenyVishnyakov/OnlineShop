using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Redis;
using OnlineShopWebApp.Service;
using OnlineShopWebApp.ViewModels;
using Serilog;

namespace OnlineShopWebApp.Areas.Admin.Controllers;

[Area(Constants.AdminRoleName)]
[Authorize(Roles = Constants.AdminRoleName)]
public class ProductManagmentController : Controller
{
    private readonly ProductService _productService;
    private readonly ReviewService _reviewService;
    private readonly RedisCacheService _redisCacheService;

    public ProductManagmentController(ProductService productService, ReviewService reviewService, RedisCacheService redisCacheService)
    {
        _productService = productService;
        _reviewService = reviewService;
        _redisCacheService = redisCacheService;
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
            await RemoveCacheAsync();
            await UpdateCacheAsync();
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
            await RemoveCacheAsync();
            await UpdateCacheAsync();
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
        await RemoveCacheAsync();
        await UpdateCacheAsync();
        return RedirectToAction(nameof(Index));
    }

    private async Task UpdateCacheAsync()
    {
        try
        {
            var products = await _productService.GetAllAsync();
            var productsVM = new List<ProductViewModel>();

            foreach (var product in products)
            {
                var rating = await _reviewService.GetRatingByProductIdAsync(product.Id);
                var productVM = Mapping.ToProductViewModel(product);
                productVM.Rating = rating;
                productsVM.Add(productVM);
            }

            var productsJson = JsonSerializer.Serialize(productsVM);
            await _redisCacheService.SetAsync(Constants.RedisCacheKey, productsJson);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Ошибка обновления кеш Redis");
        }
    }

    private async Task RemoveCacheAsync()
    {
        try
        {
            await _redisCacheService.RemoveAsync(Constants.RedisCacheKey);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Ошибка удаления кеш Redis");
        }
    }
}
