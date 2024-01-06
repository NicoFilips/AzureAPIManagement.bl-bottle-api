using FlaschenpostModels.Models;
using Newtonsoft.Json;

namespace FlaschenpostModels
{
    public class Beer
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("brandName")]
        public string? brandName { get; set; }
        [JsonProperty("name")]
        public string? name { get; set; }
        [JsonProperty("articles")]
        public List<Article>? Angebote { get; set; }
    }
}