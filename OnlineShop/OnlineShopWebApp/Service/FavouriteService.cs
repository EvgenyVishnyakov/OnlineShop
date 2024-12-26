using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.ViewModels;
using Serilog;

namespace OnlineShopWebApp.Service;

public class FavouriteService
{
    private string _userIdTemporary = "b9f2a19a-e095-47a2-9ae1-480e8cc9cdf4";
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
            var userId = await GetUserIdAsync(userLogin);
            var product = await _productService.GetAsync(productId);
            var favourite = await GetByUserAsync(userId);

            if (favourite != null)
            {
                if (IsProduct(product, favourite))
                    return;
                else
                {
                    await AddNewProductAsync(product, favourite);
                }
            }
            else
            {
                await CreateAsync(userId, product);
            }
            Log.Information($"Добавлен новый продукт {product.Name} в избранном");
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Ошибка добавления нового продукта в избранное");
        }
    }

    public async Task<string> GetUserIdAsync(string userLogin)
    {
        if (!string.IsNullOrEmpty(userLogin))
        {
            var user = await _userManager.FindByEmailAsync(userLogin);

            var userId = await _userManager.GetUserIdAsync(user);

            return userId;
        }
        else
            return _userIdTemporary;
    }

    public async Task<Favourite?> GetByUserAsync(string userId)
    {
        try
        {
            return await _favouriteRepository.GetAsync(userId);
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Ошибка получения объекта сравнения по пользователю {userId}");
            return null;
        }
    }

    public async Task<FavouriteViewModel> GetFavouriteVMAsync(string userLogin)
    {
        var userId = await GetUserIdAsync(userLogin);

        var favourite = await GetByUserAsync(userId);
        var favouriteVM = Mapping.ToFavouriteViewModel(favourite);
        return favouriteVM;
    }

    public async Task RemoveProductAsync(string userLogin, Guid productId)
    {
        try
        {
            var userId = await GetUserIdAsync(userLogin);
            var product = await _productService.GetAsync(productId);
            var favourite = await GetByUserAsync(userId);

            favourite.DecreaseAsync(product);

            await _favouriteRepository.UpdateAsync(favourite);
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
            var userId = await GetUserIdAsync(userLogin);
            await _favouriteRepository.DeleteAsync(userId);
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

    private async Task CreateAsync(string userId, Product product)
    {
        try
        {

            var newFavourite = new Favourite
            {
                UserId = userId,
                FavouriteProducts = new List<Product>()
            };
            var favourite = await _favouriteRepository.AddAsync(newFavourite);
            favourite.FavouriteProducts.Add(product);
            await _favouriteRepository.UpdateAsync(favourite);
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Ошибка создания объекта сравнение");
        }
    }
}
