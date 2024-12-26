using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repository
{
    public class CartItemDbRepository : ICartItemsRepository
    {
        private readonly DatabaseContext _databaseContext;

        public CartItemDbRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task Update(CartItem cartItem)
        {
            _databaseContext.CartItems.Update(cartItem);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
