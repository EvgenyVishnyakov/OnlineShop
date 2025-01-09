using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Interfaces;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Service;

namespace OnlineShopWebApp.Views.Shared.Components.Favourites;

public class FavouriteViewComponent : ViewComponent
{
    const string SessionPerson = "TempPerson";
    private readonly FavouriteService _favouriteService;
    private readonly IFavouriteRepository _favouritesDbRepository;

    public FavouriteViewComponent(IFavouriteRepository favouritesDbRepository, FavouriteService favouriteService)
    {
        _favouritesDbRepository = favouritesDbRepository;
        _favouriteService = favouriteService;
    }

    public async Task<IViewComponentResult> InvokeAsync(string userLogin)
    {
        int productCounts = 0;
        if (userLogin != null)
        {
            var userId = await _favouriteService.GetTransitionUserIdAsync(userLogin);
            var favouritesWithOutLogin = await _favouriteService.GetByUserAsync(userId);

            if (favouritesWithOutLogin != null)
            {
                foreach (var favouriteWithOutLogin in favouritesWithOutLogin)
                {
                    if (favouriteWithOutLogin.UserName == null)
                    {
                        favouriteWithOutLogin.UserName = userLogin;
                        await _favouritesDbRepository.UpdateAsync(favouriteWithOutLogin);
                    }
                }
            }
            var favourites = await _favouritesDbRepository.GetByLoginAsync(userLogin);
            foreach (var favourite in favourites)
            {
                var favouriteViewModel = Mapping.ToFavouriteViewModel(favourite);
                productCounts += favouriteViewModel.Amount;
            }
        }
        else
        {
            var value = HttpContext.Session.GetString(SessionPerson);
            var userId = value;
            var favourites = await _favouritesDbRepository.GetAsync(userId);
            foreach (var favourite in favourites)
            {
                var favouriteViewModel = Mapping.ToFavouriteViewModel(favourite);
                productCounts = favouriteViewModel.Amount;
            }
        }

        return View("Favourite", productCounts);
    }
}
