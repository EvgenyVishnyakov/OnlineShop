using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Service;

namespace OnlineShopWebApp.Controllers;

[Authorize]
public class FavouriteController : Controller
{
    private readonly FavouriteService _favouritesService;

    public FavouriteController(FavouriteService favouritesService)
    {
        _favouritesService = favouritesService;
    }

    public async Task<IActionResult> IndexAsync(string userLogin)
    {
        var favouriteVM = await _favouritesService.GetFavouriteVMAsync(userLogin);
        return View(favouriteVM);
    }

    [Authorize]
    public async Task<IActionResult> AddAsync(Guid productId, string userLogin)
    {
        await _favouritesService.AddProductAsync(userLogin, productId);
        return RedirectToAction("Index", new { userLogin });
    }

    public async Task<IActionResult> RemoveProductAsync(Guid productId, string userLogin)
    {
        await _favouritesService.RemoveProductAsync(userLogin, productId);
        return RedirectToAction("Index", new { userLogin });
    }

    public async Task<IActionResult> RemoveAsync(string userLogin)
    {
        await _favouritesService.DeleteAsync(userLogin);
        return RedirectToAction("Index", new { userLogin });
    }
}
