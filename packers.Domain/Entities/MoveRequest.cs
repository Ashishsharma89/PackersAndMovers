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
} 