﻿using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Helpers
{
    public class ValidationHelper
    {
        internal static void ModelValidation(object obj)
        {
            ValidationContext validationContext = new ValidationContext(obj);

            // Make Validation Results List
            List<ValidationResult> validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            if (!isValid) { throw new ArgumentException(validationResults.FirstOrDefault()?.ErrorMessage); }
        }
    }
}
