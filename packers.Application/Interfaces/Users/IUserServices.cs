using packers.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace packers.Application.Interfaces.Users
{
    public interface IUserServices
    {
        Task<User> GetUserByIdAsync(Guid userId);
        Task<User> GetUserByEmailAsync(string email);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(Guid userId);
    }
}