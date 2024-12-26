using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;

namespace OnlineShopWebApp.Service
{
    public class CartItemService
    {
        private readonly ICartItemsRepository _cartItemsRepository;

        public CartItemService(ICartItemsRepository cartItemsRepository)
        {
            _cartItemsRepository = cartItemsRepository;
        }

        public async Task UpdateAsync(List<CartItem> cartItems)
        {
            foreach (var cartItem in cartItems)
            {
                await _cartItemsRepository.Update(cartItem);
            }
        }
    }
}
