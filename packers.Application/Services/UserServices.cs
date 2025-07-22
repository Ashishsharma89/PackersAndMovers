using Packer.Application.DTOs;
using Packer.Domain.Entities;
using packers.Application.Interfaces.Repository;
using packers.Application.Interfaces.Users;
using packers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace packers.Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new Exception("User not found");
            return user;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
                throw new Exception("User not found");
            return user;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            try
            {
                await _userRepository.UpdateAsync(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            try
            {
                await _userRepository.DeleteAsync(userId);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> CustomerFormSubmit(CustomerFormSubmissionDto request)
        {
            return await _userRepository.CustomerFormSubmit(request);
        }

        public async Task<List<CustomerFormSubmissions>> GetAllCustomers()
        {
            return await _userRepository.GetAllCustomers();
        }

        public async Task<List<CustomerFormSubmissions>> GetCustomersByDateAsync(DateTime date)
        {
            return await _userRepository.GetCustomersByDateAsync(date);
        }

        public async Task<CustomerFormSubmissions?> GetCustomerByIdAsync(int id)
        {
            return await _userRepository.GetCustomerByIdAsync(id);
        }

        public async Task<bool> UpdateCustomerDeliveryStatusAsync(int id, string deliveryStatus)
        {
            return await _userRepository.UpdateCustomerDeliveryStatusAsync(id, deliveryStatus);
        }
    }
}