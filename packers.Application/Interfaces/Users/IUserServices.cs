using packers.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace packers.Application.Interfaces.Users
{
    public interface IUserServices
    {
        Task<User> GetUserByIdAsync(int userId);
        Task<User> GetUserByEmailAsync(string email);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int userId);
        Task<bool> CustomerFormSubmit(CustomerFormSubmissionDto request);
    }
}