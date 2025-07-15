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

        public async Task<Assignment> AddAsync(Assignment assignment)
        {
            await _context.Assignments.AddAsync(assignment);
            await _context.SaveChangesAsync();
            return assignment;
        }

        public async Task<Assignment> UpdateAsync(Assignment assignment)
        {
            _context.Assignments.Update(assignment);
            await _context.SaveChangesAsync();
            return assignment;
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