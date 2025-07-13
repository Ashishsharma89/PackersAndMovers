using System.Collections.Generic;
using System.Threading.Tasks;
using packers.Application.DTOs;
using packers.Domain.Entities;

namespace packers.Application.Interfaces.Users
{
    public interface IMoveService
    {
        Task<decimal> GetInstantQuoteAsync(MoveRequestDto dto);
        Task<MoveRequest> CreateMoveAsync(MoveRequestDto dto, int userId);
        Task<List<MoveRequest>> GetUserMovesAsync(int userId);
        Task<MoveRequest?> GetMoveByIdAsync(int id, int userId);
        Task<MoveRequest?> UpdateMoveAsync(int id, MoveRequestDto dto, int userId);
        Task DeleteMoveAsync(int id, int userId);
    }
} 