using Garage.Infrastructure.Interfaces;
using Garage.Models;
using System.Text.Json;

namespace Garage.Data.Init
{
    public class InitPaymentTable : IInit
    {
        private readonly ApplicationDbContext _db;

        public InitPaymentTable(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Init()
        {
            IEnumerable<PaymentFormModel> payments = _db.PaymentFormats;
            if (!payments.Any())
            {
                if (File.Exists("Files\\FormasPagamento.json"))
                {
                    string json = File.ReadAllText("Files\\FormasPagamento.json");
                    PaymentStruct? paymentsJson = JsonSerializer.Deserialize<PaymentStruct>(json);

                    if (paymentsJson != null && paymentsJson.FormasPagamento.Count > 0)
                    {
                        foreach (var paymentFormModel in paymentsJson.FormasPagamento)
                        {
                            if (paymentFormModel != null)
                                _db.PaymentFormats.Add(paymentFormModel);
                        }

                        _db.SaveChanges();
                    }
                }
            }
        }
    }
}
