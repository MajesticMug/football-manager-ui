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
            // Add AutoMapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new FootballApiMapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddTransient(_ => mapper);

            // Register request and command handlers using MediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
