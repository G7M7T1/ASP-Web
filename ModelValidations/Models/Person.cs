namespace ModelValidations.Models
{
    public class Person
    {
        public string? PersonName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }
        
        public string? Password { get; set; }
        
        public string? Confirmpassword { get; set; }
        
        public string? Price { get; set; }

        public override string ToString()
        {
            return $"{Person}";
        }
    }
}