using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Domain.Models
{
    public class Filter
    {
        [Required(ErrorMessage = "Código obrigatório")]
        public string Codigo { get; set; }
    }
}
