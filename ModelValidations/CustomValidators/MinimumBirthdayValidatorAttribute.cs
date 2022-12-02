using System.ComponentModel.DataAnnotations;

namespace ModelValidations.CustomValidators
{
    public class MinimumBirthdayValidatorAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;
                if (date.Year <= DateTime.Now.Year - 130)
                {
                    return new ValidationResult($"Your Date Of Birth Can Not Bigger Than {DateTime.Now.Year - 130}");
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
