using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Service;

namespace OnlineShopWebApp.Views.Shared.Components.Cart;

public class CartViewComponent : ViewComponent
{
    const string SessionPerson = "TempPerson";
    private readonly CartService _cartService;
    private readonly ICartsRepository _cartRepository;

    public CartViewComponent(ICartsRepository cartRepository, CartService cartService)
    {
        _cartRepository = cartRepository;
        _cartService = cartService;
    }

    public async Task<IViewComponentResult> InvokeAsync(string userLogin)
    {
        int productCounts = 0;
        if (userLogin != null)
        {
            var userId = await _cartService.GetTransitionUserIdAsync(userLogin);
            var cartsWithOutLogin = await _cartService.GetByUserIdAsync(userId);

            if (cartsWithOutLogin.Count != 0)
            {
                foreach (var cartWithOutLogin in cartsWithOutLogin)
                {
                    if (cartWithOutLogin.UserName == null)
                    {
                        cartWithOutLogin.UserName = userLogin;
                        await _cartRepository.UpdateAsync(cartWithOutLogin);
                    }
                }
            }
            var carts = await _cartRepository.GetByLoginAsync(userLogin);
            foreach (var cart in carts)
            {
                var cartViewModel = Mapping.ToCartViewModel(cart);
                productCounts += cartViewModel.Amount;
            }
        }
        else
        {
            var value = HttpContext.Session.GetString(SessionPerson);
            var userId = value;
            var carts = await _cartRepository.GetAsync(userId);
            foreach (var cart in carts)
            {
                var cartViewModel = Mapping.ToCartViewModel(cart);
                productCounts = cartViewModel.Amount;
            }
        }

        return View("Cart", productCounts);
    }
}
