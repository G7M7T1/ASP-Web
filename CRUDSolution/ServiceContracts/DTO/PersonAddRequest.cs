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
    public class PersonAddRequest
    {
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Email Address Should Be Valid")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Person Name Cannot Be Blank")]
        public string? PersonName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please Select Gender")]
        public GenderOptions? Gender { get; set; }

        [Required(ErrorMessage = "Please Select A Country")]
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
                // Person ID
                Email= Email,
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
