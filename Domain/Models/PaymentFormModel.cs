
#nullable disable

using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class PaymentFormModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("codigo")]
        public string Codigo { get; set; }

        [JsonPropertyName("descricao")]
        public string Descricao { get; set; }
    }

    public class PaymentStruct
    {
        [JsonPropertyName("paymentsModel")]
        public List<PaymentFormModel> FormasPagamento { get; set; }
    }
}
