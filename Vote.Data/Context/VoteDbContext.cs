using Microsoft.EntityFrameworkCore;
using Vote.Application.Common.Interfaces;
using Vote.Domain.Entities;

namespace Vote.Data.Context
{
    public class VoteDbContext : DbContext, IApplicationDbContext
    {
        public VoteDbContext(DbContextOptions<VoteDbContext> options) : base(options)
        {
#if SQLITE
            //try{
            //            Database.EnsureCreated();
            //}
            //catch(Exception ex){
            //            Debug.Print(ex.ToString());
            //}
#endif
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<VotePerson> Votes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema("votes");

            modelBuilder.Entity<Product>(p =>
            {
                p
                .HasMany(x => x.Persons)
                .WithMany(p => p.Products)
                .UsingEntity<VotePerson>(
                    person => person
                    .HasOne(x => x.Person)
                    .WithMany(x => x.Votes)
                    .HasForeignKey(x => x.PersonId),
                    product => product
                    .HasOne(x => x.Product)
                    .WithMany(x => x.Votes)
                    .HasForeignKey(x => x.ProductId)
                    );
            });
        }


    }
}
