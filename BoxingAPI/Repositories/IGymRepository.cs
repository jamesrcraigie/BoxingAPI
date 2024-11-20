using BoxingAPI.Models;

namespace BoxingAPI.Repositories
{
    public interface IGymRepository
    {
        Task<IEnumerable<Gym>> GetAllAsync();

        Task<Gym?> GetByIdAsync(Guid id);

        Task AddGymAsync(Gym gym);

        Task UpdateGymAsync(Gym gym);

        Task DeleteGymAsync(Guid id);
    }
}
