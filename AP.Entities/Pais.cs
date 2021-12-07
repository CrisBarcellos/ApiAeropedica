using System.ComponentModel.DataAnnotations;

namespace AP.Entities
{
    public class Pais
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(2, ErrorMessage = "O campo {0} deve ter no máximo {1} carracteres")]
        public string cd_pais { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(25, ErrorMessage = "O campo {0} deve ter no máximo {1} carracteres")]
        public string nm_pais { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Informe um número inteiro válido")]
        public decimal qt_pplc_pais { get; set; }
    }
}
