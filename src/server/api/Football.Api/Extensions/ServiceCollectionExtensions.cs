using System.Reflection;
using AutoMapper;
using Football.Api.Mappers;
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
    }
}
