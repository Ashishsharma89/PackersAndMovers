using packers.Application.DTOs;
using packers.Application.Interfaces.Repository;
using packers.Application.Interfaces.Users;
using packers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace packers.Application.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;
        public AssignmentService(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public async Task<Assignment?> GetAssignmentByIdAsync(int id)
        {
            return await _assignmentRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Assignment>> GetAllAssignmentsAsync()
        {
            return await _assignmentRepository.GetAllAsync();
        }

        public async Task<Assignment> CreateAssignmentAsync(CreateAssignmentDto assignment)
        { // Generate a random positive integer for the ID
            assignment.Status = "Assigned";
            assignment.PickupTime = DateTime.UtcNow;
            return await _assignmentRepository.AddAsync(assignment);
        }

        public async Task<Assignment> UpdateAssignmentAsync(CreateAssignmentDto assignment)
        {
            return await _assignmentRepository.UpdateAsync(assignment);
        }

        public async Task DeleteAssignmentAsync(int id)
        {
            await _assignmentRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Assignment>> GetAssignmentsByDriverIdAsync(int driverId)
        {
            return await _assignmentRepository.GetByDriverIdAsync(driverId);
        }

        public async Task<IEnumerable<Assignment>> GetAssignmentsByTruckIdAsync(int truckId)
        {
            return await _assignmentRepository.GetByTruckIdAsync(truckId);
        }

        public async Task<IEnumerable<Assignment>> GetAssignmentsByMoveRequestIdAsync(int moveRequestId)
        {
            return await _assignmentRepository.GetByMoveRequestIdAsync(moveRequestId);
        }

        public async Task<IEnumerable<Assignment>> GetAssignmentsByStatusAsync(string status)
        {
            return await _assignmentRepository.GetByStatusAsync(status);
        }
    }
} 