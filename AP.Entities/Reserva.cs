﻿using System;
using System.ComponentModel.DataAnnotations;

namespace AP.Entities
{
    public class Reserva
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "Informe um número inteiro válido")]
        public decimal cd_psgr { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage = "Informe um número inteiro válido")]
        public decimal nr_voo { get; set; }

        [MaxLength(10, ErrorMessage = "O campo {0} deve ter no máximo {1} carracteres")]
        [ValidacaoData(ErrorMessage = "Formato de data Inválido")]
        [DataType(DataType.Date)]
        public string dt_saida_voo { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Informe um número inteiro válido")]
        public decimal pc_desc_pasg { get; set; }
    }
}
