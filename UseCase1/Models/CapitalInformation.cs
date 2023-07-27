using System.Text.Json.Serialization;

namespace UseCase1.Models
{
    public class CapitalInformation
    { 
        [JsonPropertyName("latlng")]
        private string[] Latlng { get; set; }
    }
}
