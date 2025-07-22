using Packer.Application.DTOs;
using Packer.Domain.Entities;
using packers.Domain.Entities;

namespace packers.Application.Interfaces.Users
{
    public interface IUserServices
    {
        Task<User> GetUserByIdAsync(int userId);
        Task<User> GetUserByEmailAsync(string email);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int userId);
        Task<bool> CustomerFormSubmit(CustomerFormSubmissionDto request);
        Task<List<CustomerFormSubmissions>> GetAllCustomers();
        Task<List<CustomerFormSubmissions>> GetCustomersByDateAsync(DateTime date);
        Task<CustomerFormSubmissions?> GetCustomerByIdAsync(int id);
        Task<bool> UpdateCustomerDeliveryStatusAsync(int id, string deliveryStatus);
    }
}