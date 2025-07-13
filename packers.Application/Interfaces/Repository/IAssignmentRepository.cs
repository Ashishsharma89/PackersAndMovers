using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using packers.Domain.Entities;

namespace packers.Application.Interfaces.Repository
{
    public interface IAssignmentRepository
    {
        Task<Assignment?> GetByIdAsync(Guid id);
        Task<IEnumerable<Assignment>> GetAllAsync();
        Task<Assignment> AddAsync(Assignment assignment);
        Task<Assignment> UpdateAsync(Assignment assignment);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Assignment>> GetByDriverIdAsync(Guid driverId);
        Task<IEnumerable<Assignment>> GetByTruckIdAsync(Guid truckId);
        Task<IEnumerable<Assignment>> GetByMoveRequestIdAsync(Guid moveRequestId);
        Task<IEnumerable<Assignment>> GetByStatusAsync(string status);
    }
} 