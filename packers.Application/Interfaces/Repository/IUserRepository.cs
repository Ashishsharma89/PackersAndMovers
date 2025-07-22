using Packer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Packer.Application.DTOs;
using packers.Domain.Entities; // Ensure correct namespace is imported

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
        Task<List<CustomerFormSubmissions>> GetAllCustomers();
        Task<List<CustomerFormSubmissions>> GetCustomersByDateAsync(DateTime date);
        Task<CustomerFormSubmissions?> GetCustomerByIdAsync(int id);
        Task<bool> UpdateCustomerDeliveryStatusAsync(int id, string deliveryStatus);
    }
}