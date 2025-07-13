using packers.Domain.Entities;
using System;

namespace packers.Application.Interfaces.JWT
{
    public interface IJWTServices
    {
        string GenerateToken(User user);
        string GenerateRefreshToken();
        bool ValidateToken(string token);
        int GetUserIdFromToken(string token);
    }
}