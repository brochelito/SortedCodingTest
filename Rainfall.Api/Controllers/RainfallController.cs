using Microsoft.AspNetCore.Mvc;
using Rainfall.Application.Models;
using Rainfall.Application.Responses;

namespace Rainfall.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RainfallController : ControllerBase
    {
        private readonly IRainfallApiService _rainfallApiService;

        public RainfallController(IRainfallApiService rainfallApiService)
        {
            _rainfallApiService = rainfallApiService;
        }

        [HttpGet("id/{stationId}/readings")]
        public async Task<IActionResult> GetRainfallReadings(string stationId, [FromQuery] int count = 10)
        {
            var response = await _rainfallApiService.GetRainfallData(stationId, count);

            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(new ErrorResponse { Message = response.ErrorMessage });
            }
        }
    }
}
