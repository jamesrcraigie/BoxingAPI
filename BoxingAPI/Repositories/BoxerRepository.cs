using BoxingAPI.Data;
using BoxingAPI.Dtos;
using BoxingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BoxingAPI.Repositories
{
    public class BoxerRepository : IBoxerRepository
    {
        private readonly BoxingDbContext _dbContext;
        private readonly IFightRepository _fightRepository;

        public BoxerRepository(BoxingDbContext dbContext, IFightRepository fightRepository)
        {
            _dbContext = dbContext;
            _fightRepository = fightRepository;
        }

        public async Task AddBoxerAsync(Boxer boxer)
        {
            await _dbContext.Boxers.AddAsync(boxer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBoxerAsync(Guid id)
        {
            var boxer = await _dbContext.Boxers.FindAsync(id);

            if (boxer == null)
            {
                throw new KeyNotFoundException($"Boxer with id '{id}' was not found");
            }

            _dbContext.Boxers.Remove(boxer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<BoxerDto>> GetAllAsync()
        {
            var boxers = await _dbContext.Boxers.Include(b => b.RegisteredGym).Select(b => new BoxerDto
            {
                Id = b.Id,
                DateOfBirth = b.DateOfBirth,
                FirstName = b.FirstName,
                LastName = b.LastName,
                RegisteredGymId = b.RegisteredGymId,
                RegisteredGymName = b.RegisteredGym!.Name
            }).ToListAsync();

            foreach(var boxer in boxers)
            {
                boxer.Wins = await _fightRepository.GetTotalWinsByBoxerId(boxer.Id);
                boxer.Loses = await _fightRepository.GetTotalLosesByBoxerId(boxer.Id);
            }

            return boxers;
        }

        public async Task<BoxerDto?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Boxers.Include(b => b.RegisteredGym).Select(b => new BoxerDto
            {
                Id = b.Id,
                DateOfBirth = b.DateOfBirth,
                FirstName = b.FirstName,
                LastName = b.LastName,
                RegisteredGymId = b.RegisteredGymId,
                RegisteredGymName = b.RegisteredGym!.Name
            }).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task UpdateBoxerAsync(Boxer boxer)
        {
            _dbContext.Boxers.Update(boxer);
            await _dbContext.SaveChangesAsync();
        }
    }
}
