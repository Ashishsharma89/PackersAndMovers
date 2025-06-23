using Microsoft.EntityFrameworkCore;
using Packer.Domain.Entities;
using Packer.Application.Interfaces.Repository;
using Packer.Infrastructure.Data;

namespace Packer.Infrastructure.Repositories.Users
{
    public class ResetTokenRepository : IResetTokenRepository
    {
        private readonly ApplicationDbContext _context;

        public ResetTokenRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddResetTokenAsync(string email, string token)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
                throw new Exception("User not found");

            user.ResetToken = token;
            user.ResetTokenExpiry = DateTime.UtcNow.AddHours(1);
            user.IsResetTokenUsed = false;

            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserByValidTokenAsync(string email, string token)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => 
                    u.Email == email && 
                    u.ResetToken == token && 
                    !u.IsResetTokenUsed && 
                    u.ResetTokenExpiry > DateTime.UtcNow);
        }

        public async Task MarkTokenAsUsedAsync(string email, string token)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.ResetToken == token);
            
            if (user != null)
            {
                user.IsResetTokenUsed = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}