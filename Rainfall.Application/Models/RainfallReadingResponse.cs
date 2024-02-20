using System.Text.Json.Serialization;

namespace Rainfall.Application.Models
{
    public class RainfallReadingResponse
    {
        [JsonPropertyName("readings")]
        public List<RainfallReading> Readings { get; set; }
    }
}
