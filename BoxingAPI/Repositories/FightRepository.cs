using BoxingAPI.Data;
using BoxingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BoxingAPI.Repositories
{
    public class FightRepository : IFightRepository
    {
        private readonly BoxingDbContext _dbContext;

        public FightRepository(BoxingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddFightAsync(Fight fight)
        {
            await _dbContext.Fights.AddAsync(fight);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Fight?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Fights.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<int> GetTotalLosesByBoxerId(Guid id)
        {
            return await _dbContext.Fights.CountAsync(f => f.LoserBoxerId == id);
        }

        public async Task<int> GetTotalWinsByBoxerId(Guid id)
        {
            return await _dbContext.Fights.CountAsync(f => f.WinnerBoxerId == id);
        }
    }
}
