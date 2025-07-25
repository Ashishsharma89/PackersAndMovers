using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Packer.Application.DTOs;
using Packer.Domain.Entities;
using packers.Application.Interfaces.Repository;

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
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // 1. Check for existing customer by email or phone
                var customer = await _context.Customers.FirstOrDefaultAsync(c => c.email == request.Email);
                if (customer == null)
                {
                    customer = new Customers
                    {
                        customer_name = request.CustomerName,
                        phone = long.TryParse(request.Phone, out var phoneVal) ? phoneVal : 0,
                        email = request.Email,
                        created_date = DateTime.Now,
                        is_active = true,
                        is_deleted = false
                    };
                    _context.Customers.Add(customer);
                    await _context.SaveChangesAsync();
                }

                // 2. Insert new order
                var order = new Orders
                {
                    origin_location_lat = request.OriginLocationLat,
                    origin_location_long = request.OriginLocationLong,
                    destination_location_name = request.DestinationLocationName,
                    destination_location_lat = request.DestinationLocationLat,
                    destination_location_long = request.DestinationLocationLong,
                    distance_in_km = request.DistanceInKm,
                    items_json = request.ItemsJson,
                    urgency = request.Urgency,
                    estimated_price = request.EstimatedPrice,
                    order_date = DateTime.Now,
                    delivery_date = DateTime.Now.AddDays(7) // Example: 7 days delivery
                };
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                // 3. Insert new tracking record
                var tracking = new Tracking
                {
                    status = TrackingStatus.Pending.ToString(),
                    status_date = DateTime.Now,
                    is_active = true,
                    is_deleted = false
                };
                _context.Tracking.Add(tracking);
                await _context.SaveChangesAsync();

                // 4. Insert into OrderTracking
                var orderTracking = new OrderTracking
                {
                    order_id = order.order_id,
                    tracking_id = tracking.tracking_id,
                    status = TrackingStatus.Pending.ToString(),
                    status_date = DateTime.Now
                };
                _context.OrderTrackings.Add(orderTracking);
                await _context.SaveChangesAsync();

                // 5. Insert into CustomerOrders
                var customerOrder = new CustomerOrders
                {
                    customer_id = customer.customer_id,
                    order_id = order.order_id
                };
                _context.CustomerOrders.Add(customerOrder);
                await _context.SaveChangesAsync();

                // 6. Insert into CustomerFormSubmissions (for record-keeping)
                var entity = new CustomerFormSubmissions
                {
                    customer_name = request.CustomerName,
                    phone = request.Phone,
                    email = request.Email,
                    origin_location_name = request.OriginLocationName,
                    origin_location_lat = request.OriginLocationLat,
                    origin_location_long = request.OriginLocationLong,
                    destination_location_name = request.DestinationLocationName,
                    destination_location_lat = request.DestinationLocationLat,
                    destination_location_long = request.DestinationLocationLong,
                    distance_in_km = request.DistanceInKm,
                    items_json = request.ItemsJson,
                    urgency = request.Urgency,
                    estimated_price = request.EstimatedPrice,
                    delivery_status = request.DeliveryStatus,
                    form_submission_date = DateTime.Now
                };
                _context.CustomerFormSubmissions.Add(entity);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<List<CustomerFormSubmissions>> GetAllCustomers()
        {
            //
            var customerFormSubmissions = await _context.CustomerFormSubmissions
                                            .Select(c => new CustomerFormSubmissions
                                            {
                                                id = c.id,
                                                form_submission_date = c.form_submission_date,
                                                customer_name = c.customer_name,
                                                email = c.email,
                                                phone = c.phone,
                                                delivery_status = c.delivery_status
                                            })
                                            .ToListAsync();

            return customerFormSubmissions;
        }

        public async Task<List<CustomerFormSubmissions>> GetCustomersByDateAsync(DateTime date)
        {
            return await _context.CustomerFormSubmissions
                .Where(c => c.form_submission_date.Date == date.Date)
                .ToListAsync();
        }

        public async Task<CustomerFormSubmissions?> GetCustomerByIdAsync(int id)
        {
            return await _context.CustomerFormSubmissions.FirstOrDefaultAsync(c => c.id == id);
        }

        public async Task<bool> UpdateCustomerDeliveryStatusAsync(int id, string deliveryStatus)
        {
            var customer = await _context.CustomerFormSubmissions.FirstOrDefaultAsync(c => c.id == id);
            if (customer == null)
            {
                return false;
            }

            customer.delivery_status = deliveryStatus;
            _context.CustomerFormSubmissions.Update(customer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}