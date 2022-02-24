
using System.Text.Json.Serialization;

namespace CurrencyService.Models
{
    
    internal class CurrencyModel
    {
        [JsonPropertyName("item")]
        public Item Item { get; set; }
    }

    public class Item
    {
        [JsonPropertyName("moeda")]
        public string Moeda { get; set; }

        [JsonPropertyName("data_inicio")]
        public DateTime DataInicio { get; set; }

        [JsonPropertyName("data_fim")]
        public DateTime DataFim { get; set; }
    }
}
