global using FlaschenpostModels;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace FlaschenPostAPI.Helper
{
    public static class BeerHelper
    {
        public static List<Beer> GetBeerData()
        {
            List<Beer>? data = new List<Beer>();
            var json ="";
            using (var client = new HttpClient())
            {
                var endpoint = new Uri("https://flapotest.blob.core.windows.net/test/ProductData.json");
                var result = client.GetAsync(endpoint).Result;
                json = result.Content.ReadAsStringAsync().Result;
            }
            data = JsonSerializer.Deserialize<List<Beer>>(json);
            return data ?? throw new InvalidOperationException("Endpoint returned no data");
        }

        public static double BeerpricePerLitre(string pricePerUnit) 
        {
            if (Regex.IsMatch(pricePerUnit, "\\((.*?)\\)")) //Feld muss zwischen Klammern stehen
            {
                string[] units = pricePerUnit.Split('/');
                if (units[1].Contains("Liter")) 
                {
                    return double.Parse(units[0].Trim().Replace("€","").Replace("(",""));
                }
            }
            throw new Exception("Das JSON Feld hat nicht das richtige Format");
        }
        public static double GetAmountBottles(string shortDescription) 
        {
            return Double.Parse(shortDescription.Split("x")[0].Trim());
        }
    }
}
