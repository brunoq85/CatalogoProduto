using CatalogoProdutoServico.Context;
using Microsoft.EntityFrameworkCore;

namespace CatalogoProdutoServico.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServer")));

            services.AddSingleton<MongoDbContext>();

            return services;
        }
    }
}
