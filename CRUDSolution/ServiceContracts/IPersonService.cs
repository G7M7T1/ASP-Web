using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface IPersonService
    {
        PersonResponse AddPerson(PersonAddRequest? personAddRequest);

        /// <summary>
        /// Return all persons
        /// </summary>
        /// <returns>Return list of PersonResponse</returns>
        List<PersonResponse> GetAllPersons();

        /// <summary>
        /// Return the Person Object based on the given id
        /// </summary>
        /// <param name="personId"></param>
        /// <returns>Matching Person Object (PersonResponse)</returns>
        PersonResponse? GetPersonByPersonID(Guid? personId);

        /// <summary>
        /// Return All Person Object That Matches Given Search Field
        /// </summary>
        /// <param name="searchBy">Search Field</param>
        /// <param name="searchString">Search String</param>
        /// <returns>Return All Matching Persons Based On The Given Search Field (List Of PersonResponse)</returns>
        List<PersonResponse> GetFilteredPersons(string searchBy, string? searchString);
    }
}
