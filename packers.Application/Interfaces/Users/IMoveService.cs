using System.Collections.Generic;
using System.Threading.Tasks;
using packers.Application.DTOs;
using packers.Domain.Entities;

namespace packers.Application.Interfaces.Users
{
    public interface IMoveService
    {
        Task<decimal> GetInstantQuoteAsync(MoveRequestDto dto);
        Task<MoveRequest> CreateMoveAsync(MoveRequestDto dto, Guid userId);
        Task<List<MoveRequest>> GetUserMovesAsync(Guid userId);
        Task<MoveRequest?> GetMoveByIdAsync(int id, Guid userId);
        Task<MoveRequest?> UpdateMoveAsync(int id, MoveRequestDto dto, Guid userId);
        Task DeleteMoveAsync(int id, Guid userId);
    }
} 