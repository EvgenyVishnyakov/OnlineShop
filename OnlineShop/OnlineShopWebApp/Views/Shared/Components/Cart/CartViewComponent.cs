using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Service;

namespace OnlineShopWebApp.Views.Shared.Components.Cart;

public class CartViewComponent : ViewComponent
{
    private readonly CartService _cartService;
    private readonly ICartsRepository _cartRepository;

    public CartViewComponent(ICartsRepository cartRepository, CartService cartService)
    {
        _cartRepository = cartRepository;
        _cartService = cartService;
    }

    public async Task<IViewComponentResult> InvokeAsync(string userLogin)
    {
        var userId = await _cartService.GetUserIdAsync(userLogin);
        var cart = await _cartRepository.GetByUserIdAsync(userId);
        var cartViewModel = Mapping.ToCartViewModel(cart);

        var productCounts = cartViewModel?.Amount;
        return View("Cart", productCounts);
    }
}
