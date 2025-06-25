using System.Collections.Generic;
using System.Threading.Tasks;
using packers.Application.DTOs;
using packers.Application.Interfaces.Repository;
using packers.Application.Interfaces.Users;
using Packer.Domain.Entities;
using System;
using System.Linq;

namespace packers.Application.Services
{
    public class MoveService : IMoveService
    {
        private readonly IMoveRequestRepository _moveRequestRepository;
        public MoveService(IMoveRequestRepository moveRequestRepository)
        {
            _moveRequestRepository = moveRequestRepository;
        }

        public Task<decimal> GetInstantQuoteAsync(MoveRequestDto dto)
        {
            decimal basePrice = 1200;
            int numItems = dto.Items?.Count ?? 0;
            int numServices = dto.SelectedServices?.Count ?? 0;
            decimal price = basePrice + (numItems * 100) + (numServices * 200);
            return Task.FromResult(price);
        }

        public async Task<MoveRequest> CreateMoveAsync(MoveRequestDto dto, int userId)
        {
            var price = await GetInstantQuoteAsync(dto);
            var move = new MoveRequest
            {
                UserId = userId,
                SourceAddress = dto.SourceAddress,
                DestinationAddress = dto.DestinationAddress,
                MoveDate = dto.MoveDate,
                MoveTime = dto.MoveTime,
                Items = string.Join(",", dto.Items),
                Status = "Pending",
                EstimatedPrice = price,
                PhoneNumber = dto.PhoneNumber,
                ValueAddedServices = dto.ValueAddedServices != null ? string.Join(",", dto.ValueAddedServices) : null,
                SelectedServices = dto.SelectedServices != null ? string.Join(",", dto.SelectedServices) : null
            };
            return await _moveRequestRepository.AddAsync(move);
        }

        public Task<List<MoveRequest>> GetUserMovesAsync(int userId)
        {
            return _moveRequestRepository.GetByUserIdAsync(userId);
        }

        public async Task<MoveRequest> GetMoveByIdAsync(int id, int userId)
        {
            var move = await _moveRequestRepository.GetByIdAsync(id);
            if (move == null || move.UserId != userId) return null;
            return move;
        }

        public async Task<MoveRequest> UpdateMoveAsync(int id, MoveRequestDto dto, int userId)
        {
            var move = await _moveRequestRepository.GetByIdAsync(id);
            if (move == null || move.UserId != userId) return null;
            move.SourceAddress = dto.SourceAddress;
            move.DestinationAddress = dto.DestinationAddress;
            move.MoveDate = dto.MoveDate;
            move.MoveTime = dto.MoveTime;
            move.Items = string.Join(",", dto.Items);
            move.PhoneNumber = dto.PhoneNumber;
            move.ValueAddedServices = dto.ValueAddedServices != null ? string.Join(",", dto.ValueAddedServices) : null;
            move.SelectedServices = dto.SelectedServices != null ? string.Join(",", dto.SelectedServices) : null;
            return await _moveRequestRepository.UpdateAsync(move);
        }

        public async Task DeleteMoveAsync(int id, int userId)
        {
            var move = await _moveRequestRepository.GetByIdAsync(id);
            if (move != null && move.UserId == userId)
            {
                await _moveRequestRepository.DeleteAsync(id);
            }
        }
    }
} 