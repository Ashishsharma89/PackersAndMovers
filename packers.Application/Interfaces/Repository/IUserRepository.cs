using Packer.Domain.Entities;

namespace Packer.Application.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User user);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(int id);
        Task<User> UpdateAsync(User user);
    }
}