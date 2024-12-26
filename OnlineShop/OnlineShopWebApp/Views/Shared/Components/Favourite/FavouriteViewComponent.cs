using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Service;

namespace OnlineShopWebApp.Views.Shared.Components.Favourites;

public class FavouriteViewComponent : ViewComponent
{
    private readonly FavouriteService _favouriteService;
    private readonly IFavouriteRepository _favouritesListRepository;

    public FavouriteViewComponent(IFavouriteRepository favouritesListRepository, FavouriteService favouriteService)
    {
        _favouritesListRepository = favouritesListRepository;
        _favouriteService = favouriteService;
    }

    public async Task<IViewComponentResult> InvokeAsync(string userLogin)
    {
        var userId = await _favouriteService.GetUserIdAsync(userLogin);
        var favourite = await _favouritesListRepository.GetAsync(userId);
        var favouriteViewModel = Mapping.ToFavouriteViewModel(favourite);

        var productCounts = favouriteViewModel?.Amount;
        return View("Favourite", productCounts);
    }
}
