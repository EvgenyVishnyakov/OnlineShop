using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repository;

public class ProductDbRepository(DatabaseContext databaseContext) : IProductsRepository
{
    private readonly DatabaseContext _databaseContext = databaseContext;

    public async Task AddAsync(Product product)
    {
        _databaseContext.Products.Add(product);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _databaseContext.Products.Include(x => x.Images).ToListAsync();
    }

    public async Task DeleteAsync(Guid productId)
    {
        var products = await GetAllAsync();
        var product = products.FirstOrDefault(x => x.Id == productId);
        _databaseContext.Products.Remove(product);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _databaseContext.Products.Update(product);
        await _databaseContext.SaveChangesAsync();
    }
}
