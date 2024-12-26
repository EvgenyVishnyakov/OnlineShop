using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using OnlineShopWebApi.Models;
using Serilog;

namespace OnlineShopWebApi.Service;

public class ProductService
{
    private readonly IProductsRepository _productRepository;
    private readonly ImagesProvider _imagesProvider;

    public ProductService(IProductsRepository productRepository, ImagesProvider imagesProvider)
    {
        _productRepository = productRepository;
        _imagesProvider = imagesProvider;
    }

    public async Task<Product?> GetAsync(Guid id)
    {
        try
        {
            var products = await _productRepository.GetAllAsync();
            Log.Information($"Получен запрошенный продукт с ID: {id}");
            return products.FirstOrDefault(product => product.Id == id);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Ошибка получения товара из репозитория");
            return null;
        }
    }

    public async Task<List<Product>> GetAllAsync()
    {
        try
        {
            return await _productRepository.GetAllAsync();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Ошибка получения списка товаров из репозитория");
            return null;
        }
    }

    public async Task<Product?> GetAsync(string name)
    {
        var products = await GetAllAsync();
        return products.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
    }

    public async Task AddAsync(Product product)
    {
        try
        {
            await _productRepository.AddAsync(product);
            Log.Information("Добавлен товар");
        }

        catch (Exception ex)
        {
            Log.Error(ex, "Ошибка добавления товара");
        }
    }

    public async Task UpdateAsync(Product product)
    {
        try
        {
            await _productRepository.UpdateAsync(product);
            Log.Information($"Обновление данных по товару с ID: {product.Id}");
        }

        catch (Exception ex)
        {
            Log.Error(ex, "Ошибка обновления товара");
        }
    }

    public async Task<bool> DeleteAsync(Guid productId)
    {
        try
        {
            await _productRepository.DeleteAsync(productId);
            Log.Information($"Товар с ID: {productId} удален");
            return true;
        }

        catch (Exception ex)
        {
            Log.Error(ex, "Ошибка удаления товара");
            return false;
        }
    }

    public async Task<Product?> GetProductAsync(Guid productId)
    {
        var product = await GetAsync(productId);
        return product;
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        try
        {
            var products = await GetAllAsync();
            return products;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Ошибка получения списка товаров из репозитория");
            return null;
        }
    }


}


