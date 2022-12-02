using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ModelValidations.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Person Name Is Required")]
        [DisplayName("Person Name")]
        public string? PersonName { get; set; }


        [Required(ErrorMessage = "{0} Is Required")]
        [StringLength(100, MinimumLength =5, ErrorMessage ="{0} should be between {2} and {1} characters long")]
        [EmailAddress(ErrorMessage = "This Must Be A Email Address")]
        public string? Email { get; set; }


        [Required(ErrorMessage = "{0} Is Required")]
        [Phone(ErrorMessage = "This Must Be A Real Phone Number")]
        public string? Phone { get; set; }


        [Required(ErrorMessage = "{0} can not be blank")]
        public string? Password { get; set; }


        [Required(ErrorMessage = "{0} can not be blank")]
        [Compare("Password", ErrorMessage = "{1} and {0} do not match")]
        [DisplayName("Confirm Password")]
        public string? Confirmpassword { get; set; }


        [Required(ErrorMessage = "{0} Is Required")]
        [Range(0,99999, ErrorMessage = "{0} should be between {1} and {2}")]
        public double? Price { get; set; }

        public override string ToString()
        {
            return $"Person Name: {PersonName}";
        }
    }
}