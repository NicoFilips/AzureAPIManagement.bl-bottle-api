using System.Text.Json.Serialization;

namespace FlaschenpostModels.Models
{
    public class Article
    {
        [JsonPropertyName("id")]
        public int id { get; set; }
        [JsonPropertyName("shortDescription")]
        public string? shortDescription { get; set; }
        [JsonPropertyName("price")]
        public double? price { get; set; }
        [JsonPropertyName("unit")]
        public eEinheit unit;
        //[JsonProperty("unit")]
        //string? unit { get; set; }
        [JsonPropertyName("pricePerUnitText")]
        public string? pricePerUnitText { get; set; }
        [JsonPropertyName("Image")]
        public string? Image { get; set; }
    }
}
