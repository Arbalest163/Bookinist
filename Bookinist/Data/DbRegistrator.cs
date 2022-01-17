using Bookinist.Persistense.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Bookinist.Persistense;

namespace Bookinist.Data
{
    public static class DbRegistrator
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) => services
            .AddDbContext<BookinistDb>(opt =>
            {
                var connectionString = configuration["DbConnection"];
                opt.UseSqlServer(connectionString);
            })
            .AddTransient<DbInitialaizer>()
            .AddRepositories()
            ;
    }
}
