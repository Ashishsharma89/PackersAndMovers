﻿using Packer.Domain.Entities;

namespace Packer.Application.Interfaces.Users
{
    public interface IUserServices
    {
        Task<User> GetUserByIdAsync(int userId);
        Task<User> GetUserByEmailAsync(string email);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int userId);
    }
}