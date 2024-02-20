using System.Text.Json.Serialization;

namespace Rainfall.Application.Models
{
    public class RainfallReading
    {
        [JsonPropertyName("@id")]
        public string Id { get; set; }

        [JsonPropertyName("dateTime")]
        public string DateTime { get; set; }

        [JsonPropertyName("measure")]
        public string Measure { get; set; }

        [JsonPropertyName("value")]
        public double Value { get; set; }
    }
}
