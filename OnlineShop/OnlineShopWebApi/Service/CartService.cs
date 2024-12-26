using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using Serilog;

namespace OnlineShopWebApi.Service
{
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

        public async Task<string> GetUserIdAsync(string userLogin)
        {

            var user = await _userManager.FindByEmailAsync(userLogin);

            return await _userManager.GetUserIdAsync(user);
        }

        public async Task<Cart> GetCartByUserAsync(string userLogin)
        {
            try
            {
                var userId = await GetUserIdAsync(userLogin);
                return await _cartsRepository.GetByUserIdAsync(userId);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка получения по юзеру");
                return null;
            }
        }

        public async Task<Cart> GetByUserAsync(string userLogin)
        {
            try
            {
                var userId = await GetUserIdAsync(userLogin);
                return await _cartsRepository.GetByUserIdAsync(userId) ?? await CreateAsync(userId);
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

        private async Task<Cart> CreateAsync(string userId)
        {
            try
            {
                var cart = await GetNewCart(userId);
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

        private async Task<Cart> GetNewCart(string userId)
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
    }
}
