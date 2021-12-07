using System.ComponentModel.DataAnnotations;

namespace AP.Entities
{
    public class Rota
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "Informe um número inteiro válido")]
        public decimal nr_rota_voo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(3, ErrorMessage = "O campo {0} deve ter no máximo {1} carracteres")]
        public string cd_arpt_orig { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(3, ErrorMessage = "O campo {0} deve ter no máximo {1} carracteres")]
        public string cd_arpt_dest { get; set; }

        public decimal vr_pasg { get; set; }
    }
}
