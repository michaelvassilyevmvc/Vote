using System.Collections.Generic;
using Vote.Application.Dtos.Voting;

namespace Vote.Application.Persons.Queries.GetPersons
{
    public class PersonsVm
    {
        public IList<PersonDto> List { get; set; }
    }
}
