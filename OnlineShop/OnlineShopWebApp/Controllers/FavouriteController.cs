using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Service;

namespace OnlineShopWebApp.Controllers;

public class FavouriteController : Controller
{
    private readonly FavouriteService _favouritesService;

    public FavouriteController(FavouriteService favouritesService)
    {
        _favouritesService = favouritesService;
    }

    public async Task<IActionResult> IndexAsync(string userLogin)
    {
        if (userLogin != null)
        {
            var favouriteVM = await _favouritesService.GetFavouriteVMAsync(userLogin);
            return View(favouriteVM);
        }
        else
        {
            var tempUserId = HttpContext.Session.GetString(Constants.SessionPerson);
            if (tempUserId == null)
            {
                var user = new User();
                HttpContext.Session.SetString(Constants.SessionPerson, user.TransitionUserId.ToString());
            }

            var favouriteVM = await _favouritesService.GetFavouriteVMHttpContextAsync(tempUserId);
            return View(favouriteVM);
        }
    }

    public async Task<IActionResult> AddAsync(Guid productId, string userLogin)
    {
        if (userLogin != null)
        {
            await _favouritesService.AddProductAsync(userLogin, productId);
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
            await _favouritesService.AddProductHttpContextAsync(tempUserId, productId);
            return RedirectToAction("Index", new { userLogin });
        }
    }

    public async Task<IActionResult> RemoveProductAsync(Guid productId, string userLogin)
    {
        if (userLogin != null)
        {
            await _favouritesService.RemoveProductAsync(userLogin, productId);
            return RedirectToAction("Index", new { userLogin });
        }
        else
        {
            var tempUserId = HttpContext.Session.GetString(Constants.SessionPerson);
            await _favouritesService.RemoveProductHttpContextAsync(tempUserId, productId);
            return RedirectToAction("Index", new { userLogin });
        }
    }

    public async Task<IActionResult> RemoveAsync(string userLogin)
    {
        if (userLogin != null)
        {
            await _favouritesService.DeleteAsync(userLogin);
            return RedirectToAction("Index", new { userLogin });
        }
        else
        {
            var tempUserId = HttpContext.Session.GetString(Constants.SessionPerson);
            await _favouritesService.DeleteHttpContextAsync(tempUserId);
            return RedirectToAction("Index", new { userLogin });
        }
    }
}