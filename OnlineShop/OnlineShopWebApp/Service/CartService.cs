using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.ViewModels;
using Serilog;

namespace OnlineShopWebApp.Service;

public class CartService
{
    private readonly ICartsRepository _cartsRepository;
    private readonly ProductService _productService;
    private readonly UserManager<User> _userManager;


    public CartService(ProductService productService, ICartsRepository cartsRepository, UserManager<User> userManager)
    {
        _productService = productService;
        _cartsRepository = cartsRepository;
        _userManager = userManager;
    }

    public async Task<bool> AddProductAsync(string userLogin, Guid productId, Guid cartId)
    {
        try
        {
            var product = await _productService!.GetAsync(productId);
            var cart = await GetByUserLoginAsync(userLogin);
            if (cart == null)
            {
                cart = await CreateAsync(userLogin);
                await AddProductInOldCartAsync(product, cart);

            }
            else
            {
                await AddProductInOldCartAsync(product, cart);
            }

            Log.Information($"Добавлен продукт в корзину пользователя с ID: {userLogin}");
            return true;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Ошибка добавления товара");
            return false;
        }
    }

    private async Task AddProductInOldCartAsync(Product? product, Cart cart)
    {
        await cart.AddItemAsync(product!);
        await UpdateAsync(cart);
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

    public async Task<Cart?> GetByUserAsync(string userLogin)
    {
        try
        {
            var cart = await _cartsRepository.GetByLoginAsync(userLogin);
            return cart;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Ошибка получения по юзеру");
            return null;
        }
    }

    public async Task<List<Cart>>? GetByTransitionUserIdAsync(string transitionUserId)
    {
        try
        {
            var carts = await _cartsRepository.GetAllAsync(transitionUserId);
            return carts;
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Ошибка получения объекта сравнения по пользователю {transitionUserId}");
            return null;
        }
    }

    public async Task<Cart?> GetByUserLoginAsync(string userLogin)
    {
        try
        {
            var cart = await _cartsRepository.GetByLoginAsync(userLogin);
            return cart;
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Ошибка получения объекта сравнения по пользователю {userLogin}");
            return null;
        }
    }

    public async Task<CartViewModel?> GetCartVMAsync(string userLogin)
    {
        var cart = await GetByUserLoginAsync(userLogin);
        var cartVM = Mapping.ToCartViewModel(cart);
        return cartVM;
    }

    public async Task<bool> DecreaseAmountAsync(string userLogin, Guid productId)
    {
        try
        {
            var product = await _productService.GetAsync(productId);
            var cart = await GetByUserLoginAsync(userLogin);

            cart!.DecreaseCount(product);
            if (cart.Items.Count == 0)
                await _cartsRepository.DeleteByLoginAsync(userLogin);
            else
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

    private async Task<Cart> CreateAsync(string userLogin)
    {
        try
        {
            var userId = await GetUserIdAsync(userLogin);
            var cart = GetNewCart(userLogin);
            cart.TransitionUserId = userId; ;
            await _cartsRepository.AddAsync(cart);
            Log.Information($"Корзина пользователя ID: {userLogin} создана");
            return cart;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Ошибка получения корзины");
            return null;
        }
    }

    private static Cart GetNewCart(string userLogin)
    {
        return new Cart
        {
            UserName = userLogin
        };
    }

    private async Task UpdateAsync(Cart cart)
    {
        try
        {
            await _cartsRepository.UpdateAsync(cart);
            Log.Information($"Корзина пользователя ID: {cart.UserName} обновлена");
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Ошибка обновления корзины");
        }
    }

    public async Task AddProductHttpContextAsync(string userId, Guid productId)
    {
        try
        {
            var product = await _productService.GetAsync(productId);
            var cart = await _cartsRepository.GetAsync(userId);
            if (cart != null)
            {
                await AddProductInOldCartAsync(product, cart);
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
            var newCart = new Cart
            {
                TransitionUserId = userId,
                Items = new List<CartItem>()
            };
            await _cartsRepository.AddAsync(newCart);
            await newCart.AddItemAsync(product);
            await _cartsRepository.UpdateAsync(newCart);
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
            var cart = await _cartsRepository.GetAsync(tempUserId);

            cart.DecreaseCount(product);
            if (cart.Items.Count > 0)
                await _cartsRepository.UpdateAsync(cart);
            else
                await _cartsRepository.DeleteAsync(tempUserId);

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
            await _cartsRepository.DeleteAsync(tempUserId);
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Ошибка удаления товара из избранного");
        }
    }

    public async Task<CartViewModel?> GetCartVMHttpContextAsync(string tempUserId)
    {
        var cart = await _cartsRepository.GetAsync(tempUserId);
        if (cart != null && cart.TransitionUserId == tempUserId)
        {
            var cartVM = Mapping.ToCartViewModel(cart);
            return cartVM;
        }
        else if (cart == null)
        {
            var cartVM = Mapping.ToCartViewModel(cart);
            return cartVM;
        }
        else
            return null;
    }

    public async Task<Cart?> GetByUserIdAsync(string userId)
    {
        var cart = await _cartsRepository.GetAsync(userId);
        return cart;
    }
}
