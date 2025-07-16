using packers.Application.DTOs;

namespace packers.Infrastructure.Repositories.Users
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly ApplicationDbContext _context;
        public AssignmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Assignment?> GetByIdAsync(int id)
        {
            return await _context.Assignments.FindAsync(id);
        }

        public async Task<IEnumerable<Assignment>> GetAllAsync()
        {
            return await _context.Assignments.ToListAsync();
        }

        public async Task<Assignment> AddAsync(CreateAssignmentDto assignmentDto)
        {
            var assignment = new Assignment
            {
                MoveRequestId = assignmentDto.MoveRequestId,
                DriverId = assignmentDto.DriverId,
                TruckId = assignmentDto.TruckId,
                PickupTime = assignmentDto.PickupTime,
                Status = assignmentDto.Status
            };

            await _context.Assignments.AddAsync(assignment);
            await _context.SaveChangesAsync();
            return assignment;
        }

        public async Task<Assignment> UpdateAsync(CreateAssignmentDto assignmentDto)
        {
            var existingAssignment = await _context.Assignments.FindAsync(assignmentDto.MoveRequestId);
            if (existingAssignment != null)
            {
                existingAssignment.DriverId = assignmentDto.DriverId;
                existingAssignment.TruckId = assignmentDto.TruckId;
                existingAssignment.PickupTime = assignmentDto.PickupTime;

                _context.Assignments.Update(existingAssignment);
                await _context.SaveChangesAsync();
            }
            return existingAssignment;
        }

        public async Task DeleteAsync(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment != null)
            {
                _context.Assignments.Remove(assignment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Assignment>> GetByDriverIdAsync(int driverId)
        {
            return await _context.Assignments.Where(a => a.DriverId == driverId).ToListAsync();
        }

        public async Task<IEnumerable<Assignment>> GetByTruckIdAsync(int truckId)
        {
            return await _context.Assignments.Where(a => a.TruckId == truckId).ToListAsync();
        }

        public async Task<IEnumerable<Assignment>> GetByMoveRequestIdAsync(int moveRequestId)
        {
            return await _context.Assignments.Where(a => a.MoveRequestId == moveRequestId).ToListAsync();
        }

        public async Task<IEnumerable<Assignment>> GetByStatusAsync(string status)
        {
            return await _context.Assignments.Where(a => a.Status == status).ToListAsync();
        }
    }
} 