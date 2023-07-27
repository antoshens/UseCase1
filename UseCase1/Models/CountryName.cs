using System.Text.Json.Serialization;

namespace UseCase1.Models
{
    public class CountryName : Translation
    {
        [JsonPropertyName("nativeName")]
        public Dictionary<string, Translation>? NativeName { get; set; }
    }
}