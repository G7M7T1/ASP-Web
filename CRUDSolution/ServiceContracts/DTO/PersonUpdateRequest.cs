using Entities;
using ServiceContracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class PersonUpdateRequest
    {
        [Required(ErrorMessage = "Person ID Cannot Be Blank")]
        public Guid PersonID { get; set; }

        [EmailAddress(ErrorMessage = "Email Address Should Be Valid")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Person Name Cannot Be Blank")]
        public string? PersonName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        public GenderOptions? Gender { get; set; }

        public Guid? CountryID { get; set; }

        public string? Address { get; set; }

        public bool ReceiveNewsLetters { get; set; }

        /// <summary>
        /// Converts the PersonAddRequest into Person Type
        /// </summary>
        /// <returns></returns>
        public Person ToPerson()
        {
            return new Person()
            {
                PersonID= PersonID,
                Email = Email,
                PersonName = PersonName,
                DateOfBirth = DateOfBirth,
                Gender = Gender.ToString(),
                CountryID = CountryID,
                Address = Address,
                ReceiveNewsLetters = ReceiveNewsLetters
            };
        }
    }
}
