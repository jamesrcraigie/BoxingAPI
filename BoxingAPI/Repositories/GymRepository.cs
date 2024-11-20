using BoxingAPI.Data;
using BoxingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BoxingAPI.Repositories
{
    public class GymRepository : IGymRepository
    {
        public BoxingDbContext _dbContext { get; set; }

        public GymRepository(BoxingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddGymAsync(Gym gym)
        {
            await _dbContext.Gyms.AddAsync(gym);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Gym>> GetAllAsync()
        {
            return await _dbContext.Gyms.ToListAsync();
        }

        public async Task<Gym?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Gyms.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task UpdateGymAsync(Gym gym)
        {
            _dbContext.Gyms.Update(gym);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteGymAsync(Guid id)
        {
            var gym = await GetByIdAsync(id);

            if (gym == null)
            {
                throw new KeyNotFoundException($"Gym with id '{id}' was not found");
            }

            _dbContext.Gyms.Remove(gym);
            await _dbContext.SaveChangesAsync();
        }
    }
}
