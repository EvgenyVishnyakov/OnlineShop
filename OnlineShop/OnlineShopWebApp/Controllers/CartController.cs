using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Service;

namespace OnlineShopWebApp.Controllers;


public class CartController : Controller
{
    private readonly CartService _cartService;

    public CartController(CartService cartService)
    {
        _cartService = cartService;
    }

    public async Task<IActionResult> IndexAsync(string userLogin)
    {
        var cart = await _cartService.GetByUserAsync(userLogin);
        return View(Mapping.ToCartViewModel(cart));
    }

    [Authorize]
    public async Task<IActionResult> AddAsync(Guid productId, string userLogin)
    {
        await _cartService.AddProductAsync(userLogin, productId);
        return RedirectToAction("Index", new { userLogin });
    }

    public IActionResult ShowCart(string userLogin)
    {
        return RedirectToAction("Index", new { userLogin });
    }

    public async Task<IActionResult> SubtractionAsync(Guid productId, string userLogin)
    {
        await _cartService.DecreaseAmountAsync(userLogin, productId);
        return RedirectToAction("Index", new { userLogin });
    }

    public async Task<IActionResult> RemoveAsync(string userLogin, Guid cartId)
    {
        await _cartService.DeleteAsync(cartId);
        return RedirectToAction("Index", new { userLogin });
    }
}
