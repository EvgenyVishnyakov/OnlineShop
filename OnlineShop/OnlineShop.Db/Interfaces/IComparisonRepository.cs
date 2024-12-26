using OnlineShop.Db.Models;


namespace OnlineShop.Db.Interfaces;

public interface IComparisonRepository
{
    Task<Comparison> AddAsync(Comparison comparison);

    Task<Comparison?> GetAsync(string userId);

    Task<bool> UpdateAsync(Comparison comparison);

    Task<bool> DeleteAsync(string userId);
}

