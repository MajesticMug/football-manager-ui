using Football.Api.Repositories.Implementations;
using Football.Api.Repositories.Interfaces;
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

            AddRepositories(services);

            return services;
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddTransient<ICompetitionRepository, EfCompetitionRepository>();
            services.AddTransient<ITeamRepository, EfTeamRepository>();
            services.AddTransient<IPlayerRepository, EfPlayerRepository>();
        }
    }
}
