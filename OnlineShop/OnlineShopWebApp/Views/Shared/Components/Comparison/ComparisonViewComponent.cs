using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Service;

namespace OnlineShopWebApp;

public class ComparisonViewComponent : ViewComponent
{
    const string SessionPerson = "TempPerson";
    private readonly IComparisonRepository _comparisonRepository;
    private readonly ComparisonService _comparisonService;

    public ComparisonViewComponent(IComparisonRepository comparisonRepository, ComparisonService comparisonService)
    {
        _comparisonRepository = comparisonRepository;
        _comparisonService = comparisonService;
    }

    public async Task<IViewComponentResult> InvokeAsync(string userLogin)
    {
        int productCounts = 0;
        if (userLogin != null)
        {
            var userId = await _comparisonService.GetTransitionUserIdAsync(userLogin);
            var comparisonsWithOutLogin = await _comparisonService.GetByUserAsync(userId);

            if (comparisonsWithOutLogin != null)
            {
                foreach (var comparisonWithOutLogin in comparisonsWithOutLogin)
                {
                    if (comparisonWithOutLogin.UserName == null)
                    {
                        comparisonWithOutLogin.UserName = userLogin;
                        await _comparisonRepository.UpdateAsync(comparisonWithOutLogin);
                    }
                }
            }
            var comparisons = await _comparisonRepository.GetByLoginAsync(userLogin);
            foreach (var comparison in comparisons)
            {
                var comparisonViewModel = Mapping.ToComparisonViewModel(comparison);
                productCounts += comparisonViewModel.Amount;
            }
        }
        else
        {
            var value = HttpContext.Session.GetString(SessionPerson);
            var userId = value;
            var comparisons = await _comparisonRepository.GetAsync(userId);
            foreach (var comparison in comparisons)
            {
                var comparisonViewModel = Mapping.ToComparisonViewModel(comparison);
                productCounts = comparisonViewModel.Amount;
            }
        }

        return View("Comparison", productCounts);
    }
}
