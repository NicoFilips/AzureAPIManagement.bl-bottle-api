using System.Text.Json.Serialization;
using FlaschenpostModels.Models;

namespace FlaschenpostModels
{
    public class Beer
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("brandName")]
        public string? brandName { get; set; }
        [JsonPropertyName("name")]
        public string? name { get; set; }
        [JsonPropertyName("articles")]
        public List<Article>? Angebote { get; set; }
    }
}