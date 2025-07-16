using Packer.Application.DTOs;
using Packer.Domain.Entities;

namespace packers.Infrastructure.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> CustomerFormSubmit(CustomerFormSubmissionDto request)
        {
            var entity = new CustomerFormSubmissions
            {
                customer_name = request.CustomerName,
                phone = request.Phone,
                origin_location_name = request.OriginLocationName,
                origin_location_lat = request.OriginLocationLat,
                origin_location_long = request.OriginLocationLong,
                destination_location_name = request.DestinationLocationName,
                destination_location_lat = request.DestinationLocationLat,
                destination_location_long = request.DestinationLocationLong,
                distance_in_km = request.DistanceInKm,
                items_json = request.ItemsJson,
                urgency = request.Urgency,
                estimated_price = request.EstimatedPrice, // Consider fixing spelling
                delivery_status = request.DeliveryStatus
            };

            _context.CustomerFormSubmissions.Add(entity);
            int affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;
        }
    }
}