using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Vote.Domain.Entities;

namespace Vote.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<VotePerson> Votes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
