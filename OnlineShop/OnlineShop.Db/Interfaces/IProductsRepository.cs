using OnlineShop.Db.Models;

namespace OnlineShop.Db.Interfaces
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetAllAsync();

        Task AddAsync(Product product);

        Task DeleteAsync(Guid productId);

        Task UpdateAsync(Product product);
    }
}
