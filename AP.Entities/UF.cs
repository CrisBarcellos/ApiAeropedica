using System.ComponentModel.DataAnnotations;

namespace AP.Entities
{
    public class UF
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(2, ErrorMessage = "O campo {0} deve ter no máximo {1} carracteres")]
        public string sg_uf { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(25, ErrorMessage = "O campo {0} deve ter no máximo {1} carracteres")]
        public string nm_uf { get; set; }
    }
}
