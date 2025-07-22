using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using packers.Application.DTOs;
using packers.Application.Interfaces.Users;
using packers.Domain.Entities;
using packers.Infrastructure.Services.Communication;

namespace packers.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ShipmentTrackingController : ControllerBase
    {
        private readonly IShipmentService _shipmentService;
        private readonly IUserServices _userServices;
        private readonly FcmService _fcmService;
        public ShipmentTrackingController(IShipmentService shipmentService, IUserServices userServices, FcmService fcmService)
        {
            _shipmentService = shipmentService;
            _userServices = userServices;
            _fcmService = fcmService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateShipment([FromBody] CreateShipmentDto dto)
        {
            var shipment = new Shipment
            {
                UserId = dto.UserId,
                DriverId = dto.DriverId,
                EstimatedArrival = dto.EstimatedArrival,
                Status = ShipmentStatus.Pending,
                DeliveryConfirmed = false
            };
            await _shipmentService.CreateShipmentAsync(shipment);
            return Ok(new { shipment.Id });
        }

        [HttpGet("status/{shipmentId}")]
        public async Task<ActionResult<ShipmentStatusDto>> GetShipmentStatus(int shipmentId)
        {
            var shipment = await _shipmentService.GetShipmentByIdAsync(shipmentId);
            if (shipment == null)
                return NotFound();
            var dto = new ShipmentStatusDto
            {
                Status = shipment.Status.ToString(),
                EstimatedArrival = shipment.EstimatedArrival,
                DeliveryConfirmed = shipment.DeliveryConfirmed
            };
            return Ok(dto);
        }

        [HttpPost("confirm-delivery/{shipmentId}")]
        public async Task<IActionResult> ConfirmDelivery(int shipmentId)
        {
            await _shipmentService.ConfirmDeliveryAsync(shipmentId);

            // Fetch the shipment to get the userId
            var shipment = await _shipmentService.GetShipmentByIdAsync(shipmentId);
            if (shipment != null)
            {
                var user = await _userServices.GetUserByIdAsync(shipment.UserId);
                if (user != null && !string.IsNullOrEmpty(user.DeviceToken))
                {
                    await _fcmService.SendPushNotificationAsync(user.DeviceToken, "Delivery Confirmed", $"Your shipment {shipmentId} has been delivered.");
                }
            }
            return Ok(new { shipmentId, message = "Delivery confirmed." });
        }
    }
} 