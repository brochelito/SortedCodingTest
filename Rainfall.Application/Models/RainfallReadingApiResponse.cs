using System.Text.Json.Serialization;

namespace Rainfall.Application.Models
{
    public class RainfallReadingApiResponse
    {
        [JsonPropertyName("items")]
        public List<RainfallReading> Items { get; set; }
    }
}
