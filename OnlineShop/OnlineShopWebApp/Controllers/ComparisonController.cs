using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Service;

namespace OnlineShopWebApp.Controllers;

[Authorize]
public class ComparisonController : Controller
{
    private readonly ComparisonService _comparisonService;

    public ComparisonController(ComparisonService comparisonService)
    {
        _comparisonService = comparisonService;
    }

    public async Task<IActionResult> IndexAsync(string userLogin)
    {
        var comparisonVM = await _comparisonService.GetComparisonVMAsync(userLogin);
        return View(comparisonVM);
    }

    [Authorize]
    public async Task<IActionResult> AddAsync(Guid productId, string userLogin)
    {
        await _comparisonService.AddProductAsync(userLogin, productId);
        return RedirectToAction("Index", new { userLogin });
    }

    public async Task<IActionResult> RemoveProductAsync(Guid productId, string userLogin)
    {
        await _comparisonService.RemoveProductAsync(userLogin, productId);
        return RedirectToAction("Index", new { userLogin });
    }

    public async Task<IActionResult> RemoveAsync(string userLogin)
    {
        await _comparisonService.DeleteAsync(userLogin);
        return RedirectToAction("Index", new { userLogin });
    }
}
