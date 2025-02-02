using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.ViewModels;
using Serilog;

namespace OnlineShopWebApp.Service;

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

    public async Task<List<ProductViewModel>> GetAllProductVmAsync()
    {
        try
        {
            var products = await GetAllAsync();
            var productsVM = Mapping.ToProductViewModels(products);
            return productsVM;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Ошибка получения списка товаров из репозитория");
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

    public async Task<ProductViewModel> ToProductVMAsync(Guid productId)
    {
        var product = await GetAsync(productId);
        var productVM = Mapping.ToProductViewModel(product);
        return productVM;
    }

    public async Task<EditProductViewModel> ToEditProductViewModelAsync(Guid productId)
    {
        var product = await GetAsync(productId);
        var productVM = Mapping.ToEditProductViewModel(product);
        return productVM;
    }

    public async Task<Product?> GetAsync(string searchQuery)
    {
        var products = await GetAllAsync();
        return products.FirstOrDefault(x => x.Name.ToLower() == searchQuery.ToLower() || x.Category.ToLower() ==
            searchQuery.ToLower());
    }

    public async Task EditAsync(EditProductViewModel productVM)
    {
        var addedImagesPaths = await _imagesProvider.SaveFilesAsync(productVM.UploadedFiles, ImageFolder.Products);
        productVM.Images = addedImagesPaths;
        var productDb = Mapping.FromEditProductViewModel(productVM);
        await UpdateAsync(productDb);
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

    public async Task DeleteAsync(Guid productId)
    {
        try
        {
            await _productRepository.DeleteAsync(productId);
            Log.Information($"Товар с ID: {productId} удален");
        }

        catch (Exception ex)
        {
            Log.Error(ex, "Ошибка удаления товара");
        }
    }

    public async Task CreateProductAsync(CreateProductViewModel productVM)
    {
        if (productVM.UploadedFiles != null)
        {
            var imagesPath = await _imagesProvider.SaveFilesAsync(productVM.UploadedFiles, ImageFolder.Products);
            var productDB = Mapping.FromCreateProductViewModel(productVM, imagesPath);
            await AddAsync(productDB);
        }
    }

}


