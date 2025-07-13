using packers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace packers.Application.Interfaces.Repository
{
    public interface IMoveRequestRepository
    {
        Task<MoveRequest> AddAsync(MoveRequest moveRequest);
        Task<MoveRequest> UpdateAsync(MoveRequest moveRequest);
        Task DeleteAsync(int id);
        Task<MoveRequest?> GetByIdAsync(int id);
        Task<List<MoveRequest>> GetByUserIdAsync(int userId);
        Task<List<MoveRequest>> GetAllAsync();
    }
} 