using System;

namespace Vote.Domain.Entities
{
    public class VotePerson
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public DateTime VoteDate { get; set; } = DateTime.UtcNow;

    }
}
