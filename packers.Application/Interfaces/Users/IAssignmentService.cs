using packers.Application.DTOs;
using packers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace packers.Application.Interfaces.Users
{
    public interface IAssignmentService
    {
        Task<Assignment?> GetAssignmentByIdAsync(int id);
        Task<IEnumerable<Assignment>> GetAllAssignmentsAsync();
        Task<Assignment> CreateAssignmentAsync(CreateAssignmentDto assignment);
        Task<Assignment> UpdateAssignmentAsync(CreateAssignmentDto assignment);
        Task DeleteAssignmentAsync(int id);
        Task<IEnumerable<Assignment>> GetAssignmentsByDriverIdAsync(int driverId);
        Task<IEnumerable<Assignment>> GetAssignmentsByTruckIdAsync(int truckId);
        Task<IEnumerable<Assignment>> GetAssignmentsByMoveRequestIdAsync(int moveRequestId);
        Task<IEnumerable<Assignment>> GetAssignmentsByStatusAsync(string status);
    }
} 