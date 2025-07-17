using Packer.Application.DTOs;
using packers.Domain.Entities;

namespace packers.Application.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User user);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(int id);
        Task<User> UpdateAsync(User user);
        Task<bool> DeleteAsync(int id);
        Task<bool> CustomerFormSubmit(CustomerFormSubmissionDto request);
    }
}