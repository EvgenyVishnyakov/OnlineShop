using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repository
{
    public class ComparisonsDbRepository : IComparisonRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ComparisonsDbRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Comparison> AddAsync(Comparison comparison)
        {
            await _databaseContext.Comparisons.AddAsync(comparison);
            await _databaseContext.SaveChangesAsync();
            return comparison;
        }

        public async Task<List<Comparison>>? GetAsync(string userId)
        {
            var comparisons = await _databaseContext.Comparisons.Include(x => x.ComparisonProducts).Where(x => x.TransitionUserId == userId).ToListAsync();
            return comparisons;
        }

        public async Task<List<Comparison>>? GetByLoginAsync(string userLogin)
        {
            var comparisons = await _databaseContext.Comparisons.Include(x => x.ComparisonProducts).Where(x => x.UserName == userLogin).ToListAsync();
            return comparisons;
        }


        public async Task<bool> UpdateAsync(Comparison comparison)
        {
            _databaseContext.Comparisons.Update(comparison);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(string userId)
        {
            var comparisons = await GetAsync(userId);
            foreach (var comparison in comparisons)
            {
                _databaseContext.Comparisons.Remove(comparison);
                await _databaseContext.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> DeleteByLoginAsync(string userLogin)
        {
            var comparisons = await GetByLoginAsync(userLogin);
            foreach (var comparison in comparisons)
            {
                _databaseContext.Comparisons.Remove(comparison);
                await _databaseContext.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> DeleteByLoginAndComparisonAsync(string userLogin, Comparison comparison)
        {
            var comparisons = await GetByLoginAsync(userLogin);
            foreach (var item in comparisons)
            {
                if (item.Id == comparison.Id)
                {
                    _databaseContext.Comparisons.Remove(item);
                    await _databaseContext.SaveChangesAsync();
                }
            }
            return true;
        }
    }
}
