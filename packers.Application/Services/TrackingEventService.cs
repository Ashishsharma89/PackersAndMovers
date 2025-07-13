using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using packers.Application.Interfaces.Repository;
using packers.Application.Interfaces.Users;
using packers.Domain.Entities;

namespace packers.Application.Services
{
    public class TrackingEventService : ITrackingEventService
    {
        private readonly ITrackingEventRepository _trackingEventRepository;
        public TrackingEventService(ITrackingEventRepository trackingEventRepository)
        {
            _trackingEventRepository = trackingEventRepository;
        }

        public async Task<IEnumerable<TrackingEvent>> GetTrackingEventsByShipmentIdAsync(int shipmentId)
        {
            return await _trackingEventRepository.GetByShipmentIdAsync(shipmentId);
        }

        public async Task AddTrackingEventAsync(TrackingEvent trackingEvent)
        {
            await _trackingEventRepository.AddAsync(trackingEvent);
        }

        public async Task<IEnumerable<TrackingEvent>> GetAllTrackingEventsAsync()
        {
            return await _trackingEventRepository.GetAllAsync();
        }
    }
} 