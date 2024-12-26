using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using Serilog;

namespace OnlineShopWebApp.Service;

public class CartService
{
    private readonly string temporaryLogin = "b9f2a19a-e095-47a2-9ae1-480e8cc9cdf4";
    private readonly ICartsRepository _cartsRepository;
    private readonly ProductService _productService;
    private readonly UserManager<User> _userManager;


    public CartService(ProductService productService, ICartsRepository cartsRepository, UserManager<User> userManager)
    {
        _productService = productService;
        _cartsRepository = cartsRepository;
        _userManager = userManager;
    }

    public async Task<bool> AddProductAsync(string userLogin, Guid productId)
    {
        try
        {

            var product = await _productService.GetAsync(productId);
            var cart = await GetByUserAsync(userLogin);
            var userId = await GetUserIdAsync(userLogin);
            cart ??= await CreateAsync(userId);
            await cart.AddItemAsync(product);

            await UpdateAsync(cart);
            Log.Information($"Добавлен продукт в корзину пользователя с ID: {userId}");
            return true;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Ошибка добавления товара");
            return false;
        }
    }

    public async Task<string?> GetUserIdAsync(string userLogin)
    {
        if (userLogin != null)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == userLogin);

            var userId = await _userManager.GetUserIdAsync(user);

            return userId;
        }
        else
            return temporaryLogin;

    }

    public async Task<Cart?> GetByUserAsync(string userLogin)
    {
        try
        {
            var userId = await GetUserIdAsync(userLogin);
            var cart = await _cartsRepository.GetByUserIdAsync(userId);
            return cart;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Ошибка получения по юзеру");
            return null;
        }
    }

    public async Task<bool> DecreaseAmountAsync(string userLogin, Guid productId)
    {
        try
        {
            var userId = await GetUserIdAsync(userLogin);
            var product = await _productService.GetAsync(productId);
            var cart = await GetByUserAsync(userLogin);
            cart.DecreaseCount(product);
            await _cartsRepository.UpdateAsync(cart);
            Log.Information($"Уменьшено количество продукта с ID: {productId}");
            return true;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Ошибка уменьшения продукта");
            return false;
        }
    }

    public async Task<bool> DeleteAsync(Guid cartId)
    {
        try
        {
            await _cartsRepository.DeleteAsync(cartId);
            Log.Information($"Корзина удалена");
            return true;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Ошибка удаления корзины");
            return false;
        }
    }

    public async Task<Cart?> GetAsync(Guid cartId)
    {
        try
        {
            return await _cartsRepository.GetCartByCartIdAsync(cartId);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Ошибка получения корзины");
            return null;
        }
    }

    private async Task<Cart> CreateAsync(string userId)
    {
        try
        {
            var cart = GetNewCart(userId);
            await _cartsRepository.AddAsync(cart);
            Log.Information($"Корзина пользователя ID: {userId} создана");
            return cart;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Ошибка получения корзины");
            return null;
        }
    }

    private static Cart GetNewCart(string userId)
    {
        return new Cart
        {
            UserId = userId
        };
    }

    private async Task UpdateAsync(Cart cart)
    {
        try
        {
            await _cartsRepository.UpdateAsync(cart);
            Log.Information($"Корзина пользователя ID: {cart.UserId} обновлена");
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Ошибка обновления корзины");
        }
    }
}
