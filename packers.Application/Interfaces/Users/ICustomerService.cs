using packers.Application.DTOs;
using packers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace packers.Application.Interfaces.Users
{
    public interface ICustomerService
    {
        Task<Customer?> GetCustomerByIdAsync(int id);
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> CreateCustomerAsync(CustomerDto customer);
        Task<Customer> UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int id);
        Task<Customer?> GetCustomerByEmailAsync(string email);
        Task<Customer?> GetCustomerByPhoneAsync(string phone);
        Task<IEnumerable<Customer>> GetCustomersByStatusAsync(string status);
    }
} 