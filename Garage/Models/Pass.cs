using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Garage.Models
{
    public class Pass
    {
        [Key]
        public int Id { get; set; }
        public string Garagem { get; set; }
        public string CarroPlaca { get; set; }
        public string CarroMarca { get; set; }
        public string CarroModelo { get; set; }
        public string DataHoraEntrada { get; set; }
        public string DataHoraSaida { get; set; }
        public string FormaPagamento { get; set; }
        public string PrecoTotal { get; set; }
    }

    public class PassStruct
    {
        public List<Pass> Passagens { get; set; }
    }
}
