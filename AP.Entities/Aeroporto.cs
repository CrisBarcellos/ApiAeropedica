using System.ComponentModel.DataAnnotations;

namespace AP.Entities
{
    public class Aeroporto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(3, ErrorMessage = "O campo {0} deve ter no máximo {1} carracteres")]
        public string cd_arpt { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(2, ErrorMessage = "O campo {0} deve ter no máximo {1} carracteres")]
        public string cd_pais { get; set; }

        [MaxLength(2, ErrorMessage = "O campo {0} deve ter no máximo {1} carracteres")]
        public string sg_uf { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(30, ErrorMessage = "O campo {0} deve ter no máximo {1} carracteres")]
        public string nm_cidd { get; set; }
    }
}
