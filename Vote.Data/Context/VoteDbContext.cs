using Microsoft.EntityFrameworkCore;
using Vote.Domain.Entities;

namespace Vote.Data.Context
{
    public class VoteDbContext : DbContext
    {
        public VoteDbContext(DbContextOptions<VoteDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<ProductVote> Votes { get; set; }


    }
}
