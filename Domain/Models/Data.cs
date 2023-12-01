
#nullable disable

namespace Domain.Models
{
    public class Data
    {
        public IEnumerable<Pass> Passes { get; set; }

        public IEnumerable<GaragensModel> Garagens { get; set; }

        public IEnumerable<PaymentFormModel> PaymentForms { get; set; }


        public void EstimarValores()
        {
            if (Passes != null && Garagens != null)
            {
                foreach (Pass pass in Passes)
                {
                    if (pass.FormaPagamento == "MEN")
                        pass.PrecoTotal = "0";
                    else
                    {
                        int valor1_hora = int.Parse(Garagens.ToList()[0].Preco_1aHora);
                        int valorAdicional = int.Parse(Garagens.ToList()[0].Preco_HorasExtra);

                        int total = valor1_hora;
                        TimeSpan rest = pass.ElipsedTimeOnGarage;

                        if (pass.ElipsedTimeOnGarage.TotalSeconds >= 3600)
                        {
                            rest = pass.ElipsedTimeOnGarage.Subtract(new TimeSpan(1, 0, 0));
                        }

                        int days = rest.Days;
                        int hours = rest.Hours;
                        int minutes = rest.Minutes;

                        total += (((days * 24) + hours) * valorAdicional);
                        total += minutes > 30 ? valorAdicional : valorAdicional / 2;
                        pass.PrecoTotal = total.ToString();
                    }
                }
            }
        }
    }
}
