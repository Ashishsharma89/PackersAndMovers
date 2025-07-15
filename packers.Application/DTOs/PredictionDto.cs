namespace Packer.Application.DTOs
{
    public class PredictionDto
    {
        public float DistanceKm { get; set; }
        public bool Urgency { get; set; }
        public List<ItemDto> Items { get; set; }
    }
    public class PricePrediction { public float Score { get; set; } }

    public class TruckPrediction
    {
        [Microsoft.ML.Data.ColumnName("PredictedLabel")]
        public string TruckSize { get; set; }
    }
}
