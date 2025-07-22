using packers.Application.DTOs;
using packers.Application.Interfaces.Repository;
using packers.Application.Interfaces.Users;
using packers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace packers.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<Customer> CreateCustomerAsync(CustomerDto customer)
        {
            // Set default values
            customer.RegistrationDate = DateTime.UtcNow;
            customer.Status = "Active";

            return await _customerRepository.AddAsync(customer);
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            return await _customerRepository.UpdateAsync(customer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _customerRepository.DeleteAsync(id);
        }

        public async Task<Customer?> GetCustomerByEmailAsync(string email)
        {
            return await _customerRepository.GetByEmailAsync(email);
        }

        public async Task<Customer?> GetCustomerByPhoneAsync(string phone)
        {
            return await _customerRepository.GetByPhoneAsync(phone);
        }

        public async Task<IEnumerable<Customer>> GetCustomersByStatusAsync(string status)
        {
            var allCustomers = await _customerRepository.GetAllAsync();
            return allCustomers.Where(c => c.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
        }
    }
} 