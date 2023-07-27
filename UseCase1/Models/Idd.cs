using System.Text.Json.Serialization;

namespace UseCase1.Models
{
    public class Idd
    {
        [JsonPropertyName("root")]
        public string Root { get; set; }

        [JsonPropertyName("suffixes")]
        public string[] Suffixes { get; set; }
    }
}
