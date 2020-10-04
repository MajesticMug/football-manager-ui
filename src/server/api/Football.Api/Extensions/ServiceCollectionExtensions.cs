using System.Reflection;
using AutoMapper;
using Football.Api.Mappers;
using Football.Api.Repositories.Implementations;
using Football.Api.Repositories.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Football.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFootballApi(this IServiceCollection services)
        {
            AddAutoMapper(services);

            AddCqrs(services);

            AddRepositories(services);

            return services;
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new FootballApiMapperProfile()); });

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddTransient(_ => mapper);
        }

        private static void AddCqrs(IServiceCollection services)
        {
            // Register request and command handlers using MediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddTransient<ICompetitionRepository, CompetitionRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
        }
    }
}
