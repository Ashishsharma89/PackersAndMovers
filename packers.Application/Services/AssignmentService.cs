using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using packers.Application.Interfaces.Repository;
using packers.Application.Interfaces.Users;
using packers.Domain.Entities;

namespace packers.Application.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;
        public AssignmentService(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public async Task<Assignment?> GetAssignmentByIdAsync(Guid id)
        {
            return await _assignmentRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Assignment>> GetAllAssignmentsAsync()
        {
            return await _assignmentRepository.GetAllAsync();
        }

        public async Task<Assignment> CreateAssignmentAsync(Assignment assignment)
        {
            assignment.Id = Guid.NewGuid();
            assignment.Status = "Assigned";
            assignment.PickupTime = DateTime.UtcNow;
            return await _assignmentRepository.AddAsync(assignment);
        }

        public async Task<Assignment> UpdateAssignmentAsync(Assignment assignment)
        {
            return await _assignmentRepository.UpdateAsync(assignment);
        }

        public async Task DeleteAssignmentAsync(Guid id)
        {
            await _assignmentRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Assignment>> GetAssignmentsByDriverIdAsync(Guid driverId)
        {
            return await _assignmentRepository.GetByDriverIdAsync(driverId);
        }

        public async Task<IEnumerable<Assignment>> GetAssignmentsByTruckIdAsync(Guid truckId)
        {
            return await _assignmentRepository.GetByTruckIdAsync(truckId);
        }

        public async Task<IEnumerable<Assignment>> GetAssignmentsByMoveRequestIdAsync(Guid moveRequestId)
        {
            return await _assignmentRepository.GetByMoveRequestIdAsync(moveRequestId);
        }

        public async Task<IEnumerable<Assignment>> GetAssignmentsByStatusAsync(string status)
        {
            return await _assignmentRepository.GetByStatusAsync(status);
        }
    }
} 