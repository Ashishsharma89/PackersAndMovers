using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using packers.Domain.Entities;

namespace packers.Application.Interfaces.Users
{
    public interface IAssignmentService
    {
        Task<Assignment?> GetAssignmentByIdAsync(Guid id);
        Task<IEnumerable<Assignment>> GetAllAssignmentsAsync();
        Task<Assignment> CreateAssignmentAsync(Assignment assignment);
        Task<Assignment> UpdateAssignmentAsync(Assignment assignment);
        Task DeleteAssignmentAsync(Guid id);
        Task<IEnumerable<Assignment>> GetAssignmentsByDriverIdAsync(Guid driverId);
        Task<IEnumerable<Assignment>> GetAssignmentsByTruckIdAsync(Guid truckId);
        Task<IEnumerable<Assignment>> GetAssignmentsByMoveRequestIdAsync(Guid moveRequestId);
        Task<IEnumerable<Assignment>> GetAssignmentsByStatusAsync(string status);
    }
} 