using System.Collections;
using System.Collections.Generic;

namespace Vote.Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public List<VotePerson> Votes { get; set; } = new List<VotePerson>();

    }
}
