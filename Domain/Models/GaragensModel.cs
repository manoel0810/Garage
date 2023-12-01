
#nullable disable

using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class GaragensModel
    {
        [JsonPropertyName("codigo")]
        public string Codigo { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("preco_1aHora")]
        public string Preco_1aHora { get; set; }

        [JsonPropertyName("preco_HorasExtra")]
        public string Preco_HorasExtra { get; set; }

        [JsonPropertyName("preco_Mensalista")]
        public string Preco_Mensalista { get; set; }
    }

    public class GaragensStruct
    {
        [JsonPropertyName("garagens")]
        public IEnumerable<GaragensModel> Garagens { get; set;}
    }
}
