using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaschenpostModels.Models
{
    public class Article
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("shortDescription")]
        public string? shortDescription { get; set; }
        [JsonProperty("price")]
        public double? price { get; set; }
        [JsonProperty("unit")]
        public eEinheit unit;
        //[JsonProperty("unit")]
        //string? unit { get; set; }
        [JsonProperty("pricePerUnitText")]
        public string? pricePerUnitText { get; set; }
        [JsonProperty("Image")]
        public string? Image { get; set; }
    }
}
