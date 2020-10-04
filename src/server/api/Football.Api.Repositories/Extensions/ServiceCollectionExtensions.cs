using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Football.Api.Repositories.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFootballApiEntityFrameworkCore(this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<FootballDbContext>(builder => builder.UseSqlServer(connectionString));

            return services;
        }
    }
}
