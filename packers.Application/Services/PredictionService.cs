using Microsoft.ML;
using Packer.Application.DTOs;
using Packer.Application.Interfaces.ML;

namespace Packer.Application.Services
{
    public class PredictionService : IPredictionService
    {
        private readonly MLContext _mlContext;
        private readonly PredictionEngine<TransportDto, PricePrediction> _priceEngine;
        private readonly PredictionEngine<TransportDto, TruckPrediction> _truckEngine;
        public PredictionService()
        {
            _mlContext = new MLContext();

            var priceModel = _mlContext.Model.Load(Path.Combine("MLModels", "PriceModel.zip"), out _);
            var truckModel = _mlContext.Model.Load(Path.Combine("MLModels", "TruckModel.zip"), out _);

            try
            {
                // IMPORTANT: The input class (TransportData) must match the input schema the model was trained with.
                _priceEngine = _mlContext.Model.CreatePredictionEngine<TransportDto, PricePrediction>(priceModel);
                _truckEngine = _mlContext.Model.CreatePredictionEngine<TransportDto, TruckPrediction>(truckModel);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new InvalidOperationException($"Model input schema mismatch. Ensure the model was trained with input columns: DistanceKm, Volume, Urgency. Details: {ex.Message}", ex);
            }
        }
        public PredictionResultDto Predict(float distanceKm, List<ItemDto> items, bool urgency)
        {
            //Convert items to total volume in cubic meters
            float totalVolume = items.Sum(i => (i.Length * i.Breadth * i.Height) / 1_000_000f);

            var input = new TransportDto
            {
                DistanceKm = distanceKm,
                Volume = totalVolume,
                Urgency = urgency
            };

            var price = _priceEngine.Predict(input).Score;
            var truck = _truckEngine.Predict(input).TruckSize;

            return new PredictionResultDto
            {
                Price = (float)Math.Round(price, 2),
                TruckSize = truck
            };
        }
    }
}
