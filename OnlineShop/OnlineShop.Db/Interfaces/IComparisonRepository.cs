using OnlineShop.Db.Models;


namespace OnlineShop.Db.Interfaces;

public interface IComparisonRepository
{
    Task<Comparison> AddAsync(Comparison comparison);

    Task<List<Comparison>>? GetAsync(string userId);

    Task<bool> UpdateAsync(Comparison comparison);

    Task<bool> DeleteAsync(string userId);

    Task<List<Comparison?>> GetByLoginAsync(string userLogin);

    Task<bool> DeleteByLoginAsync(string userLogin);

    Task<bool> DeleteByLoginAndComparisonAsync(string userLogin, Comparison comparison);
}

