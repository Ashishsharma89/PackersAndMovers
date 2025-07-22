using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using packers.Application.DTOs;
using packers.Application.Interfaces.Users;
using packers.Domain.Entities;

namespace packers.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TrackingEventController : ControllerBase
    {
        private readonly ITrackingEventService _trackingEventService;
        public TrackingEventController(ITrackingEventService trackingEventService)
        {
            _trackingEventService = trackingEventService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddTrackingEvent([FromBody] CreateTrackingEventDto dto)
        {
            var trackingEvent = new TrackingEvent
            {
                ShipmentId = dto.ShipmentId,
                Timestamp = DateTime.UtcNow,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                Status = Enum.TryParse<TrackingStatus>(dto.Status, out var status) ? status : TrackingStatus.InTransit
            };
            await _trackingEventService.AddTrackingEventAsync(trackingEvent);
            return Ok(new { trackingEvent.Id });
        }

        [HttpGet("shipment/{shipmentId}")]
        public async Task<IActionResult> GetTrackingEventsByShipment(int shipmentId)
        {
            var events = await _trackingEventService.GetTrackingEventsByShipmentIdAsync(shipmentId);
            return Ok(events);
        }
    }
} 