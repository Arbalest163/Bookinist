using Bookinist.Interfaces;
using Bookinist.Persistense.Entityes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookinist.Persistense
{
    static public class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) => services
            .AddTransient<IRepository<Book>, BookRepository>()
            .AddTransient<IRepository<Genre>, DbRepository<Genre>>()
            .AddTransient<IRepository<Author>, DbRepository<Author>>()
            .AddTransient<IRepository<Seller>, DbRepository<Seller>>()
            .AddTransient<IRepository<Buyer>, DbRepository<Buyer>>()
            .AddTransient<IRepository<Deal>, DbRepository<Deal>>()
            ;
    }
}
