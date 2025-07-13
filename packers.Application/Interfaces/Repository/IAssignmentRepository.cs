using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using packers.Domain.Entities;

namespace packers.Application.Interfaces.Repository
{
    public interface IAssignmentRepository
    {
        Task<Assignment?> GetByIdAsync(int id);
        Task<IEnumerable<Assignment>> GetAllAsync();
        Task<Assignment> AddAsync(Assignment assignment);
        Task<Assignment> UpdateAsync(Assignment assignment);
        Task DeleteAsync(int id);
        Task<IEnumerable<Assignment>> GetByDriverIdAsync(int driverId);
        Task<IEnumerable<Assignment>> GetByTruckIdAsync(int truckId);
        Task<IEnumerable<Assignment>> GetByMoveRequestIdAsync(int moveRequestId);
        Task<IEnumerable<Assignment>> GetByStatusAsync(string status);
    }
} 