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
            var transitionUserId = await _cartService.GetTransitionUserIdAsync(userLogin);
            var cartWithOutLogin = await _cartService.GetByUserIdAsync(transitionUserId);
            var cart = await _cartService.GetByUserAsync(userLogin);

            if (cartWithOutLogin != null)
            {
                if (cart != null)
                {
                    if (cartWithOutLogin.UserName == null)
                    {
                        cartWithOutLogin.UserName = userLogin;
                        cart.Items.AddRange(cartWithOutLogin.Items);
                        await _cartRepository.UpdateAsync(cart);
                        await _cartRepository.DeleteCartAsync(cartWithOutLogin);
                        var cartViewModel = Mapping.ToCartViewModel(cart);
                        productCounts += cartViewModel != null ? cartViewModel.Amount : 0;
                    }
                }
                else
                {
                    var userId = await _cartService.GetUserIdAsync(userLogin);
                    cartWithOutLogin.TransitionUserId = userId;
                    cartWithOutLogin.UserName = userLogin;
                    await _cartRepository.UpdateAsync(cartWithOutLogin);
                    var cartViewModel = Mapping.ToCartViewModel(cartWithOutLogin);
                    productCounts += cartViewModel != null ? cartViewModel.Amount : 0;
                }

            }
            else
            {
                var cartViewModel = Mapping.ToCartViewModel(cart);
                productCounts += cartViewModel != null ? cartViewModel.Amount : 0;
            }
        }
        else
        {
            var value = HttpContext.Session.GetString(SessionPerson);
            var userId = value;
            var cart = await _cartRepository.GetAsync(userId);
            var cartViewModel = Mapping.ToCartViewModel(cart);
            productCounts = cartViewModel != null ? cartViewModel.Amount : 0;
        }

        return View("Cart", productCounts);
    }
}
