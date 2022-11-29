using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Vote.Application.Common.Interfaces;
using Vote.Data.Context;

namespace Vote.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureData(this IServiceCollection services)
        {
            services.AddDbContext<VoteDbContext>(options => options.UseSqlite("Data Source=VoteDb.sqlite3"));
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<VoteDbContext>());
            return services;
        }
    }
}
