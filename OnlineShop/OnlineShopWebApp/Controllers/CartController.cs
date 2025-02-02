using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
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
        if (userLogin != null)
        {
            var cartVM = await _cartService.GetCartVMAsync(userLogin);
            return View(cartVM);
        }
        else
        {
            var tempUserId = HttpContext.Session.GetString(Constants.SessionPerson);
            if (tempUserId == null)
            {
                var user = new User();
                HttpContext.Session.SetString(Constants.SessionPerson, user.TransitionUserId.ToString());
            }

            var cartVM = await _cartService.GetCartVMHttpContextAsync(tempUserId);
            return View(cartVM);
        }
    }

    public async Task<IActionResult> AddAsync(Guid productId, string userLogin, Guid cartId)
    {
        if (userLogin != null)
        {
            await _cartService.AddProductAsync(userLogin, productId, cartId);
            return RedirectToAction("Index", new { userLogin });
        }
        else
        {
            var value = HttpContext.Session.GetString(Constants.SessionPerson);
            if (value == null)
            {
                var user = new User();
                HttpContext.Session.SetString(Constants.SessionPerson, user.TransitionUserId.ToString());
            }
            var tempUserId = HttpContext.Session.GetString(Constants.SessionPerson);
            await _cartService.AddProductHttpContextAsync(tempUserId, productId);
            return RedirectToAction("Index", new { userLogin });
        }
    }

    public IActionResult ShowCart(string userLogin)
    {
        return RedirectToAction("Index", new { userLogin });
    }

    public async Task<IActionResult> SubtractionAsync(Guid productId, string userLogin)
    {
        if (userLogin != null)
        {
            await _cartService.DecreaseAmountAsync(userLogin, productId);
            return RedirectToAction("Index", new { userLogin });
        }
        else
        {
            var tempUserId = HttpContext.Session.GetString(Constants.SessionPerson);
            await _cartService.RemoveProductHttpContextAsync(tempUserId, productId);
            return RedirectToAction("Index", new { userLogin });
        }
    }

    public async Task<IActionResult> RemoveAsync(string userLogin, Guid cartId)
    {
        if (userLogin != null)
        {
            await _cartService.DeleteAsync(cartId);
            return RedirectToAction("Index", new { userLogin });
        }
        else
        {
            var tempUserId = HttpContext.Session.GetString(Constants.SessionPerson);
            await _cartService.DeleteHttpContextAsync(tempUserId);
            return RedirectToAction("Index", new { userLogin });
        }

    }
}
