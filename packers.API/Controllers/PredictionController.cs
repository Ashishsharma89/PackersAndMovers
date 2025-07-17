using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Packer.Application.DTOs;
using Packer.Application.Interfaces.ML;
using Packer.Application.Services;

namespace Packer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PredictionController : ControllerBase
    {
        private readonly IPredictionService _service;
        public PredictionController()
        {
            _service = new PredictionService();
        }
        [HttpPost]
        public IActionResult Predict([FromBody] PredictionDto request)
        {
            var result = _service.Predict(request.DistanceKm, request.Items, request.Urgency);
            return Ok(result);
        }
    }
}
