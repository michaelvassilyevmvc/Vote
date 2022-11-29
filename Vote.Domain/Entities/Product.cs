using System.Collections;
using System.Collections.Generic;
using Vote.Domain.Enums;

namespace Vote.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Category Category { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<Person> Persons { get; set; } = new List<Person>();

        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        public List<VotePerson> Votes { get; set; } = new List<VotePerson>();
    }
}
