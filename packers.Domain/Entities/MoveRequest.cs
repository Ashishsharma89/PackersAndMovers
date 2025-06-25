public class MoveRequest
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string SourceAddress { get; set; }
    public string DestinationAddress { get; set; }
    public DateTime MoveDate { get; set; }
    public string Items { get; set; } // Comma-separated for simplicity
    public string Status { get; set; } // "Pending", "Scheduled", "Completed"
    public decimal? EstimatedPrice { get; set; }
    public string PhoneNumber { get; set; } // New field for user contact
    public string? ValueAddedServices { get; set; } // Comma-separated value-added services
    public string? SelectedServices { get; set; } // Comma-separated selected services (Packing,Loading,...)
    public TimeSpan? MoveTime { get; set; } // Optional move time
} 