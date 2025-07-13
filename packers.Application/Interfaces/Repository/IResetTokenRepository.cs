using packers.Domain.Entities;
using System.Threading.Tasks;

namespace packers.Application.Interfaces.Repository
{
    public interface IResetTokenRepository
    {
        Task<User> AddResetTokenAsync(string email, string token);
        Task<User?> GetUserByValidTokenAsync(string email, string token);
        Task MarkTokenAsUsedAsync(string email, string token);
    }
}