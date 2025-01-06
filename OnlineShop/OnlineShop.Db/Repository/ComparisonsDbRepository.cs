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
            try
            {
                await _databaseContext.Comparisons.AddAsync(comparison);
                await _databaseContext.SaveChangesAsync();
                return comparison;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Comparison?> GetAsync(string userId)
        {
            var comparison = await _databaseContext.Comparisons.Include(x => x.ComparisonProducts).FirstOrDefaultAsync(x => x.TransitionUserId == userId);
            return comparison;
        }

        public async Task<Comparison?> GetByLoginAsync(string userLogin)
        {
            var comparison = await _databaseContext.Comparisons.Include(x => x.ComparisonProducts).FirstOrDefaultAsync(x => x.UserName == userLogin);
            return comparison;
        }


        public async Task<bool> UpdateAsync(Comparison comparison)
        {
            _databaseContext.Comparisons.Update(comparison);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(string userId)
        {
            var comparison = await GetAsync(userId);
            _databaseContext.Comparisons.Remove(comparison);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteByLoginAsync(string userLogin)
        {
            var comparison = await GetByLoginAsync(userLogin);
            _databaseContext.Comparisons.Remove(comparison);
            await _databaseContext.SaveChangesAsync();
            return true;
        }
    }
}
