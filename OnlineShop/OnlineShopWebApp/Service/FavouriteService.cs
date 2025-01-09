using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.ViewModels;
using Serilog;

namespace OnlineShopWebApp.Service;

public class FavouriteService
{
    private readonly IFavouriteRepository _favouriteRepository;
    private readonly ProductService _productService;
    private readonly UserManager<User> _userManager;

    public FavouriteService(IFavouriteRepository favouriteRepository, ProductService productService, UserManager<User> userManager)
    {
        _favouriteRepository = favouriteRepository;
        _productService = productService;
        _userManager = userManager;
    }

    public async Task AddProductAsync(string userLogin, Guid productId)
    {
        try
        {
            var product = await _productService.GetAsync(productId);
            var favourites = await GetByUserLoginAsync(userLogin);

            if (favourites.Count != 0)
            {
                foreach (var favourite in favourites)
                {
                    if (IsProduct(product, favourite))
                        return;
                    else
                    {
                        await AddNewProductAsync(product, favourite);
                    }
                }
            }
            else
            {
                var userId = await GetUserIdAsync(userLogin);
                await CreateAsync(userId, product, userLogin);
            }
            Log.Information($"Добавлен новый продукт {product.Name} в избранном");
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Ошибка добавления нового продукта в избранное");
        }
    }

    public async Task<string> GetTransitionUserIdAsync(string userLogin)
    {
        var user = await _userManager.FindByEmailAsync(userLogin);

        var TransitionUserId = user.TransitionUserId.ToString();

        return TransitionUserId;
    }

    public async Task<string> GetUserIdAsync(string userLogin)
    {
        var user = await _userManager.FindByEmailAsync(userLogin);

        var userId = user.Id;

        return userId;
    }

    public async Task<List<Favourite>?> GetByUserAsync(string userId)
    {
        try
        {
            var favourites = await _favouriteRepository.GetAsync(userId);
            return favourites;
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Ошибка получения объекта сравнения по пользователю {userId}");
            return null;
        }
    }

    public async Task<List<Favourite>?> GetByUserLoginAsync(string userLogin)
    {
        try
        {
            var favourites = await _favouriteRepository.GetByLoginAsync(userLogin);
            return favourites;
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Ошибка получения объекта сравнения по пользователю {userLogin}");
            return null;
        }
    }

    public async Task<List<FavouriteViewModel>> GetFavouriteVMAsync(string userLogin)
    {
        var listFavouriteVM = new List<FavouriteViewModel>();
        var userId = await GetTransitionUserIdAsync(userLogin);
        var nextFavourites = await GetByUserAsync(userId);
        if (nextFavourites != null)
        {
            foreach (var nextFavourite in nextFavourites)
            {
                if (nextFavourite.UserName == null)
                {
                    nextFavourite.UserName = userLogin;
                    await _favouriteRepository.UpdateAsync(nextFavourite);
                }
            }
        }
        var favourites = await GetByUserLoginAsync(userLogin);
        foreach (var favourite in favourites)
        {
            var favouriteVM = Mapping.ToFavouriteViewModel(favourite);
            listFavouriteVM.Add(favouriteVM);
        }
        return listFavouriteVM;
    }

    public async Task RemoveProductAsync(string userLogin, Guid productId)
    {
        try
        {
            var product = await _productService.GetAsync(productId);
            var favourites = await GetByUserLoginAsync(userLogin);
            foreach (var favourite in favourites)
            {
                favourite.Decrease(product);
                if (favourite.FavouriteProducts.Count == 0)
                    await _favouriteRepository.DeleteByLoginAsync(userLogin);
                else
                    await _favouriteRepository.UpdateAsync(favourite);
            }
            Log.Information($"Товар {product.Name} удален из избранного");
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Ошибка удаления товара из избранного");
        }
    }

    public async Task DeleteAsync(string userLogin)
    {
        try
        {
            await _favouriteRepository.DeleteByLoginAsync(userLogin);
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Ошибка удаления товара из избранного");
        }
    }

    private async Task AddNewProductAsync(Product product, Favourite? favourite)
    {
        try
        {
            favourite.FavouriteProducts.Add(product);
            await _favouriteRepository.UpdateAsync(favourite);

        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Ошибка добавления товара в избранное");
        }
    }

    private bool IsProduct(Product product, Favourite favouritesList)
    {
        return favouritesList.FavouriteProducts.Any(x => x.Id == product.Id);
    }

    private async Task CreateAsync(string userId, Product product, string userLogin)
    {
        try
        {
            var newFavourite = new Favourite
            {
                TransitionUserId = userId,
                UserName = userLogin,
                FavouriteProducts = new List<Product>()
            };
            var favourite = await _favouriteRepository.AddAsync(newFavourite);
            favourite.FavouriteProducts.Add(product);
            await _favouriteRepository.UpdateAsync(newFavourite);
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Ошибка создания объекта избранное");
        }
    }

    public async Task AddProductHttpContextAsync(string userId, Guid productId)
    {
        try
        {
            var product = await _productService.GetAsync(productId);
            var favourites = await GetByUserAsync(userId);
            if (favourites.Count != 0)
            {
                foreach (var favourite in favourites)
                {
                    if (IsProduct(product, favourite))
                        return;
                    else
                    {
                        await AddNewProductAsync(product, favourite);
                    }
                }
            }
            else
            {
                await CreateHttpAsync(userId, product);
            }
            Log.Information($"Добавлен новый продукт {product.Name} в избранное");
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Ошибка добавления нового продукта в избранное");
        }
    }

    private async Task CreateHttpAsync(string userId, Product product)
    {
        try
        {

            var newFavourite = new Favourite
            {
                TransitionUserId = userId,
                FavouriteProducts = new List<Product>()
            };
            var favourite = await _favouriteRepository.AddAsync(newFavourite);
            favourite.FavouriteProducts.Add(product);
            await _favouriteRepository.UpdateAsync(favourite);
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Ошибка создания объекта избранное");
        }
    }

    public async Task RemoveProductHttpContextAsync(string tempUserId, Guid productId)
    {
        try
        {
            var product = await _productService.GetAsync(productId);
            var favourites = await GetByUserAsync(tempUserId);
            foreach (var favourite in favourites)
            {
                favourite.Decrease(product);
                await _favouriteRepository.UpdateAsync(favourite);
            }
            Log.Information($"Товар {product.Name} удален из избранного");
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Ошибка удаления товара из избранного");
        }
    }

    public async Task DeleteHttpContextAsync(string tempUserId)
    {
        try
        {
            await _favouriteRepository.DeleteAsync(tempUserId);
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Ошибка удаления товара из избранного");
        }
    }

    public async Task<List<FavouriteViewModel>>? GetFavouriteVMHttpContextAsync(string tempUserId)
    {
        var favourites = await GetByUserAsync(tempUserId);
        var favouriteVM = new List<FavouriteViewModel>();
        if (favourites.Count != 0)
        {
            foreach (var favourite in favourites)
            {
                if (favourite.UserName != null && favourite.TransitionUserId == tempUserId)
                {
                    continue;
                }
                favouriteVM.Add(Mapping.ToFavouriteViewModel(favourite));
            }
        }
        else
        {
            foreach (var favourite in favourites)
                favouriteVM.Add(Mapping.ToFavouriteViewModel(favourite));
        }

        return favouriteVM;
    }
}
