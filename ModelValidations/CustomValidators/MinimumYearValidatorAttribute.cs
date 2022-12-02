using System.ComponentModel.DataAnnotations;

namespace ModelValidations.CustomValidators
{
    public class MinimumYearValidatorAttribute: ValidationAttribute
    {
        public int MinimumYears { get; set; } = DateTime.Now.Year;

        public string DefaultErrorMessage { get; set; } = "Your Date Of Birth Can Not Bigger Than {0}";

        public MinimumYearValidatorAttribute() { }

        public MinimumYearValidatorAttribute(int minimumYear) 
        {
            MinimumYears = minimumYear;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;
                if (date.Year >= MinimumYears)
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, MinimumYears));
                }

                else
                {
                    return ValidationResult.Success;
                }
            }

            return null;
        }
    }
}
