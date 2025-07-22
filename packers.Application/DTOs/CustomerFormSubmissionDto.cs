using System.ComponentModel.DataAnnotations;

namespace Packer.Application.DTOs
{
    public class CustomerFormSubmissionDto
    {
        [Required(ErrorMessage = "Customer name is required.")]
        [StringLength(100, ErrorMessage = "Customer name must be under 100 characters.")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Origin location name is required.")]
        public string OriginLocationName { get; set; }

        [Required(ErrorMessage = "Origin latitude is required.")]
        public string OriginLocationLat { get; set; }

        [Required(ErrorMessage = "Origin longitude is required.")]
        public string OriginLocationLong { get; set; }

        [Required(ErrorMessage = "Destination location name is required.")]
        public string DestinationLocationName { get; set; }

        [Required(ErrorMessage = "Destination latitude is required.")]
        public string DestinationLocationLat { get; set; }

        [Required(ErrorMessage = "Destination longitude is required.")]
        public string DestinationLocationLong { get; set; }

        [Required(ErrorMessage = "Distance (in km) is required.")]
        public decimal DistanceInKm { get; set; }

        [Required(ErrorMessage = "Items JSON is required.")]
        public string ItemsJson { get; set; }

        public bool Urgency { get; set; } = false;

        [Required(ErrorMessage = "Estimated price is required.")]
        public decimal EstimatedPrice { get; set; }

        [Required(ErrorMessage = "Delivery status is required.")]
        public string DeliveryStatus { get; set; }
    }
}
