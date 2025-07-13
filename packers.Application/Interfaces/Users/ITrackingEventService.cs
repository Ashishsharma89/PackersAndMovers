using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using packers.Domain.Entities;

namespace packers.Application.Interfaces.Users
{
    public interface ITrackingEventService
    {
        Task<IEnumerable<TrackingEvent>> GetTrackingEventsByShipmentIdAsync(int shipmentId);
        Task AddTrackingEventAsync(TrackingEvent trackingEvent);
        Task<IEnumerable<TrackingEvent>> GetAllTrackingEventsAsync();
    }
} 