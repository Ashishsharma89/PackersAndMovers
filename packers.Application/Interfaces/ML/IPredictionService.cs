using Packer.Application.DTOs;

namespace Packer.Application.Interfaces.ML
{
    public interface IPredictionService
    {
        public PredictionResultDto Predict(float distanceKm, List<ItemDto> items, bool urgency);
    }
}
