using BoxingAPI.Dtos;
using BoxingAPI.Models;

namespace BoxingAPI.Repositories
{
    public interface IBoxerRepository
    {
        Task<IEnumerable<BoxerDto>> GetAllAsync();

        Task<BoxerDto?> GetByIdAsync(Guid id);

        Task AddBoxerAsync(Boxer boxer);

        Task UpdateBoxerAsync(Boxer boxer);

        Task DeleteBoxerAsync(Guid id);
    }
}
