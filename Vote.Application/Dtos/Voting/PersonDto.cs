using Vote.Application.Common.Mappings;
using Vote.Domain.Entities;

namespace Vote.Application.Dtos.Voting
{
    public class PersonDto : IMapFrom<Person>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

    }
}
