using BoxingAPI.Dtos;
using BoxingAPI.Models;

namespace BoxingAPI.Repositories
{
    public interface IFightRepository
    {
        Task<Fight?> GetByIdAsync(Guid id);

        Task AddFightAsync(Fight fight);

        Task<int> GetTotalWinsByBoxerId(Guid id);

        Task<int> GetTotalLosesByBoxerId(Guid id);
    }
}
