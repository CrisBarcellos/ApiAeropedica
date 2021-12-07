using System.ComponentModel.DataAnnotations;

namespace AP.Entities
{
    public class Equipamento
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(3, ErrorMessage = "O campo {0} deve ter no máximo {1} carracteres")]
        public string cd_eqpt { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(38, ErrorMessage = "O campo {0} deve ter no máximo {1} carracteres")]
        public string nm_eqpt { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(13, ErrorMessage = "O campo {0} deve ter no máximo {1} carracteres")]
        public string dc_tipo_eqpt { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Informe um número inteiro válido")]
        [ValidacaoMotor(ErrorMessage = "Escolha um valor entre 1 e 4")]
        public decimal qt_motor { get; set; }

        [MaxLength(1, ErrorMessage = "O campo {0} deve ter no máximo {1} carracteres")]
        [ValidacaoEquipamento(ErrorMessage = "Escolha M ou R")]
        public string ic_tipo_prps { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Informe um número inteiro válido")]
        public decimal qt_psgr { get; set; }
    }
}
