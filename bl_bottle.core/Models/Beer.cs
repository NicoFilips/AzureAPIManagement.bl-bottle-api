using System.Text.Json.Serialization;
using FlaschenpostModels.Models;

namespace FlaschenpostModels
{
    public class Beer
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("brandName")]
        public string? BrandName { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("articles")]
        public List<Article>? Offers { get; set; }
    }
}