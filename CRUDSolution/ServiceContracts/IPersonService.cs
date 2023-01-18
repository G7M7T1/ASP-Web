using ServiceContracts.DTO;
using ServiceContracts.Enums;
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

        /// <summary>
        /// Return Sorted List Of Person
        /// </summary>
        /// <param name="allPersons">List Of Persons</param>
        /// <param name="sortBy">Name Of The Property (Key)</param>
        /// <param name="sortOrder">ASC or DESC</param>
        /// <returns>Return Sorted Persons As PersonResponse List</returns>
        List<PersonResponse> GetSortedPersons(List<PersonResponse> allPersons, string sortBy, SortOrderOptions sortOrder);

        /// <summary>
        /// Update The Specified Person Details Based On The Given Person ID
        /// </summary>
        /// <param name="personUpdateRequest">Person Details To Update Including Person ID</param>
        /// <returns>Return Person Object (PersonResponse)</returns>
        PersonResponse UpdatePerson(PersonUpdateRequest? personUpdateRequest);

        /// <summary>
        /// Delete A Person Based On The Given Person ID
        /// </summary>
        /// <param name="personId">PersonID</param>
        /// <returns>Return True or False</returns>
        bool DeletePerson(Guid? personId);
    }
}
