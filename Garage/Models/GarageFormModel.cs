
#nullable disable

using System.ComponentModel.DataAnnotations;

namespace Garage.Models
{
    public class GarageFormModel
    {
        [Key]
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Preco_1aHora { get; set; }
        public string Preco_HorasExtra { get; set; }
        public string Preco_Mensalista { get; set; }
    }

    public class GarageStruct
    {
        public List<GarageFormModel> Garagens { get; set; }
    }
}
