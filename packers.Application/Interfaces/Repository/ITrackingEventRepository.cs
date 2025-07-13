using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using packers.Domain.Entities;

namespace packers.Application.Interfaces.Repository
{
    public interface ITrackingEventRepository
    {
        Task<TrackingEvent?> GetByIdAsync(Guid id);
        Task<IEnumerable<TrackingEvent>> GetByShipmentIdAsync(Guid shipmentId);
        Task AddAsync(TrackingEvent trackingEvent);
        Task<IEnumerable<TrackingEvent>> GetAllAsync();
    }
} 