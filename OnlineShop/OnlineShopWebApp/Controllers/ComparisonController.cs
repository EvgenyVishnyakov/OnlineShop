using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Service;

namespace OnlineShopWebApp.Controllers;

public class ComparisonController : Controller
{
    private readonly ComparisonService _comparisonService;

    public ComparisonController(ComparisonService comparisonService)
    {
        _comparisonService = comparisonService;
    }

    public async Task<IActionResult> IndexAsync(string userLogin)
    {
        if (userLogin != null)
        {
            var comparisonVM = await _comparisonService.GetComparisonVMAsync(userLogin);
            return View(comparisonVM);
        }
        else
        {
            var tempUserId = HttpContext.Session.GetString(Constants.SessionPerson);
            if (tempUserId == null)
            {
                var user = new User();
                HttpContext.Session.SetString(Constants.SessionPerson, user.TransitionUserId.ToString());
            }

            var comparisonVM = await _comparisonService.GetComparisonVMHttpContextAsync(tempUserId);
            return View(comparisonVM);
        }
    }

    public async Task<IActionResult> AddAsync(Guid productId, string userLogin)
    {
        if (userLogin != null)
        {
            await _comparisonService.AddProductAsync(userLogin, productId);
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
            await _comparisonService.AddProductHttpContextAsync(tempUserId, productId);
            return RedirectToAction("Index", new { userLogin });
        }
    }

    public async Task<IActionResult> RemoveProductAsync(Guid productId, string userLogin)
    {
        if (userLogin != null)
        {
            await _comparisonService.RemoveProductAsync(userLogin, productId);
            return RedirectToAction("Index", new { userLogin });
        }
        else
        {
            var tempUserId = HttpContext.Session.GetString(Constants.SessionPerson);
            await _comparisonService.RemoveProductHttpContextAsync(tempUserId, productId);
            return RedirectToAction("Index", new { userLogin });
        }
    }

    public async Task<IActionResult> RemoveAsync(string userLogin)
    {
        if (userLogin != null)
        {
            await _comparisonService.DeleteAsync(userLogin);
            return RedirectToAction("Index", new { userLogin });
        }
        else
        {
            var tempUserId = HttpContext.Session.GetString(Constants.SessionPerson);
            await _comparisonService.DeleteHttpContextAsync(tempUserId);
            return RedirectToAction("Index", new { userLogin });
        }
    }
}
