using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.ViewModels;
using Serilog;

namespace OnlineShopWebApp.Service;

public class ComparisonService
{
    private readonly IComparisonRepository _comparisonRepository;
    private readonly ProductService _productService;
    private readonly UserManager<User> _userManager;

    public ComparisonService(IComparisonRepository comparisonRepository, ProductService productService, UserManager<User> userManager)
    {
        _comparisonRepository = comparisonRepository;
        _productService = productService;
        _userManager = userManager;
    }

    public async Task AddProductAsync(string userLogin, Guid productId)
    {
        try
        {
            var product = await _productService.GetAsync(productId);
            var comparisons = await GetByUserLoginAsync(userLogin);
            if (comparisons.Count != 0)
            {
                foreach (var comparison in comparisons)
                {
                    if (IsProduct(product, comparison))
                        return;
                    else
                    {
                        await AddNewProductAsync(product, comparison);
                    }
                }
            }
            else
            {
                var userId = await GetUserIdAsync(userLogin);
                await CreateAsync(userId, product, userLogin);
            }

            Log.Information($"Добавлен новый продукт {product.Name} в сравнение");
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Ошибка добавления нового продукта в сравнение");
        }
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

    public async Task<List<Comparison>?> GetByUserAsync(string userId)
    {
        try
        {
            var comparissons = await _comparisonRepository.GetAsync(userId);
            return comparissons;
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Ошибка получения объекта сравнения по пользователю {userId}");
            return null;
        }
    }

    public async Task<List<Comparison?>> GetByUserLoginAsync(string userLogin)
    {
        try
        {
            var comparissons = await _comparisonRepository.GetByLoginAsync(userLogin);
            return comparissons;
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Ошибка получения объекта сравнения по пользователю {userLogin}");
            return null;
        }
    }

    public async Task<List<ComparisonViewModel>> GetComparisonVMAsync(string userLogin)
    {
        var listComparisonVM = new List<ComparisonViewModel>();
        var userId = await GetTransitionUserIdAsync(userLogin);
        var nextComparisons = await GetByUserAsync(userId);
        if (nextComparisons != null)
        {
            foreach (var nextComparison in nextComparisons)
            {
                if (nextComparison.UserName == null)
                {
                    nextComparison.UserName = userLogin;
                    await _comparisonRepository.UpdateAsync(nextComparison);
                }
            }
        }
        var comparisons = await GetByUserLoginAsync(userLogin);
        foreach (var comparison in comparisons)
        {
            var comparisonVM = Mapping.ToComparisonViewModel(comparison);
            listComparisonVM.Add(comparisonVM);
        }
        return listComparisonVM;
    }

    public async Task RemoveProductAsync(string userLogin, Guid productId)
    {
        try
        {
            //var userId = await GetTransitionUserIdAsync(userLogin);
            var product = await _productService.GetAsync(productId);
            var comparisons = await GetByUserLoginAsync(userLogin);
            foreach (var comparison in comparisons)
            {
                comparison.Decrease(product);
                await _comparisonRepository.UpdateAsync(comparison);
            }
            Log.Information($"Товар {product.Name} удален из сравнения");
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Ошибка удаления товара из сравнения");
        }
    }

    public async Task DeleteAsync(string userLogin)
    {
        try
        {
            await _comparisonRepository.DeleteByLoginAsync(userLogin);
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Ошибка удаления товара из сравнения");
        }
    }

    private async Task AddNewProductAsync(Product product, Comparison? comparison)
    {
        try
        {
            comparison.ComparisonProducts.Add(product);
            await _comparisonRepository.UpdateAsync(comparison);

        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Ошибка добавления товара в сравнение");
        }
    }

    private bool IsProduct(Product product, Comparison comparisonList)
    {
        return comparisonList.ComparisonProducts.Any(x => x.Id == product.Id);
    }

    private async Task CreateAsync(string userId, Product product, string userLogin)
    {
        try
        {

            var newComparison = new Comparison
            {
                TransitionUserId = userId,
                UserName = userLogin,
                ComparisonProducts = new List<Product>()
            };
            var comparison = await _comparisonRepository.AddAsync(newComparison);
            comparison.ComparisonProducts.Add(product);
            await _comparisonRepository.UpdateAsync(comparison);
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Ошибка создания объекта сравнение");
        }
    }

    public async Task AddProductHttpContextAsync(string userId, Guid productId)
    {
        try
        {
            var product = await _productService.GetAsync(productId);
            var comparisons = await GetByUserAsync(userId);
            if (comparisons.Count != 0)
            {
                foreach (var comparison in comparisons)
                {
                    if (IsProduct(product, comparison))
                        return;
                    else
                    {
                        await AddNewProductAsync(product, comparison);
                    }
                }
            }
            else
            {
                await CreateHttpAsync(userId, product);
            }
            Log.Information($"Добавлен новый продукт {product.Name} в сравнение");
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Ошибка добавления нового продукта в сравнение");
        }
    }

    private async Task CreateHttpAsync(string userId, Product product)
    {
        try
        {

            var newComparison = new Comparison
            {
                TransitionUserId = userId,
                ComparisonProducts = new List<Product>()
            };
            var comparison = await _comparisonRepository.AddAsync(newComparison);
            comparison.ComparisonProducts.Add(product);
            await _comparisonRepository.UpdateAsync(comparison);
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Ошибка создания объекта сравнение");
        }
    }

    public async Task RemoveProductHttpContextAsync(string tempUserId, Guid productId)
    {
        try
        {
            var product = await _productService.GetAsync(productId);
            var comparisons = await GetByUserAsync(tempUserId);
            foreach (var comparison in comparisons)
            {
                comparison.Decrease(product);
                await _comparisonRepository.UpdateAsync(comparison);
            }
            Log.Information($"Товар {product.Name} удален из сравнения");
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Ошибка удаления товара из сравнения");
        }
    }

    public async Task DeleteHttpContextAsync(string tempUserId)
    {
        try
        {
            await _comparisonRepository.DeleteAsync(tempUserId);
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Ошибка удаления товара из сравнения");
        }
    }

    public async Task<List<ComparisonViewModel>>? GetComparisonVMHttpContextAsync(string tempUserId)
    {
        var comparisons = await GetByUserAsync(tempUserId);
        var comparisonsVM = new List<ComparisonViewModel>();
        if (comparisons.Count != 0)
        {
            foreach (var comparison in comparisons)
            {
                if (comparison.UserName != null && comparison.TransitionUserId == tempUserId)
                {
                    continue;
                }
                comparisonsVM.Add(Mapping.ToComparisonViewModel(comparison));
            }
        }
        else
        {
            foreach (var comparison in comparisons)
                comparisonsVM.Add(Mapping.ToComparisonViewModel(comparison));
        }

        return comparisonsVM;
    }
}
