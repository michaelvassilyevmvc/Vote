using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using Vote.Domain.Entities;
using PersonsProducts = Vote.Domain.Entities.Vote;

namespace Vote.Data.Context
{
    public class VoteDbContext : DbContext
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
        public DbSet<Domain.Entities.Vote> Votes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema("products");

            modelBuilder.Entity<Product>(p =>
            {
                p
                .HasMany(x => x.Persons)
                .WithMany(p => p.Products)
                .UsingEntity<PersonsProducts>(
                    person => person
                    .HasOne(x => x.Person)
                    .WithMany(x => x.Votes)
                    .HasForeignKey(x=>x.PersonId),
                    product => product
                    .HasOne(x => x.Product)
                    .WithMany(x=>x.Votes)
                    .HasForeignKey(x=>x.ProductId)
                    );
            });
        }


    }
}
