﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.Entities
{
    public class Validacoes 
    {       
    }

    public class ValidacaoSexo : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Convert.ToString(value) == "M" || Convert.ToString(value) == "F")
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage);
        }
    }

    public class ValidacaoData : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                Convert.ToDateTime(value);
                return ValidationResult.Success;
            }
            catch 
            {
                return new ValidationResult(ErrorMessage);
            }
        }
    }

    public class ValidacaoEstadoCivil : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Convert.ToString(value) == "S" || Convert.ToString(value) == "C" || Convert.ToString(value) == "V")
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage);
        }
    }
}