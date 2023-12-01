#nullable disable

namespace Garage.Models
{
    public class PaymentFormModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }

    public class PaymentStruct
    {
        public List<PaymentFormModel> FormasPagamento { get; set; }
    }
}
