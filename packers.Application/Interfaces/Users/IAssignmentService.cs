using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using packers.Domain.Entities;

namespace packers.Application.Interfaces.Users
{
    public interface IAssignmentService
    {
        Task<Assignment?> GetAssignmentByIdAsync(int id);
        Task<IEnumerable<Assignment>> GetAllAssignmentsAsync();
        Task<Assignment> CreateAssignmentAsync(Assignment assignment);
        Task<Assignment> UpdateAssignmentAsync(Assignment assignment);
        Task DeleteAssignmentAsync(int id);
        Task<IEnumerable<Assignment>> GetAssignmentsByDriverIdAsync(int driverId);
        Task<IEnumerable<Assignment>> GetAssignmentsByTruckIdAsync(int truckId);
        Task<IEnumerable<Assignment>> GetAssignmentsByMoveRequestIdAsync(int moveRequestId);
        Task<IEnumerable<Assignment>> GetAssignmentsByStatusAsync(string status);
    }
} 