
#nullable disable

using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class Pass
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("garagem")]
        public string Garagem { get; set; }

        [JsonPropertyName("carroPlaca")]
        public string CarroPlaca { get; set; }

        [JsonPropertyName("carroMarca")]
        public string CarroMarca { get; set; }

        [JsonPropertyName("carroModelo")]
        public string CarroModelo { get; set; }

        [JsonPropertyName("dataHoraEntrada")]
        public string DataHoraEntrada { get; set; }

        [JsonPropertyName("dataHoraSaida")]
        public string DataHoraSaida { get; set; }

        [JsonPropertyName("formaPagamento")]
        public string FormaPagamento { get; set; }

        [JsonPropertyName("precoTotal")]
        public string PrecoTotal { get; set; }
    }

    public class PassStruct
    {
        [JsonPropertyName("passes")]
        public List<Pass> Passagens { get; set; }
    }
}
