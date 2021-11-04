using System;
using System.ComponentModel.DataAnnotations;

namespace AP.Entities
{
    public class Passageiro
    {   

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "Informe um número inteiro válido")]
        public int cd_psgr { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(30, ErrorMessage = "O campo {0} deve ter no máximo {1} carracteres")]
        public string nm_psgr { get; set; }

        [MaxLength(1, ErrorMessage = "O campo {0} deve ter no máximo {1} carracteres")]
        [ValidacaoSexo(ErrorMessage = "Escolha M para Masculino ou F para Feminino")]
        public string ic_sexo_psgr { get; set; }

        [MaxLength(10, ErrorMessage = "O campo {0} deve ter no máximo {1} carracteres")]
        [ValidacaoData(ErrorMessage = "Formato de data Inválido")]
        [DataType(DataType.Date)]
        public string dt_nasc_psgr { get; set; }

        [MaxLength(2, ErrorMessage = "O campo {0} deve ter no máximo {1} carracteres")]
        public string cd_pais { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(1, ErrorMessage = "O campo {0} deve ter no máximo {1} carracteres")]
        [ValidacaoEstadoCivil(ErrorMessage = "Escolha S para Solteiro, C para Casado ou V para Viúvo")]
        public string ic_estd_civil { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Informe um número inteiro válido")]
        public decimal cd_psgr_resp { get; set; }
    }  
}
