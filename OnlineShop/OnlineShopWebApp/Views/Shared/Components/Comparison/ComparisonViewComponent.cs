using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Service;

namespace OnlineShopWebApp.Views.Shared.Components.Comparison;

public class ComparisonViewComponent : ViewComponent
{
    private readonly IComparisonRepository _comparisonRepository;
    private readonly ComparisonService _comparisonService;

    public ComparisonViewComponent(IComparisonRepository comparisonRepository, ComparisonService comparisonService)
    {
        _comparisonRepository = comparisonRepository;
        _comparisonService = comparisonService;
    }

    public async Task<IViewComponentResult> InvokeAsync(string userLogin)
    {
        var userId = await _comparisonService.GetUserIdAsync(userLogin);
        var comparison = await _comparisonRepository.GetAsync(userId);
        var comparisonViewModel = Mapping.ToComparisonViewModel(comparison);

        var productCounts = comparisonViewModel?.Amount;
        return View("Comparison", productCounts);
    }
}
