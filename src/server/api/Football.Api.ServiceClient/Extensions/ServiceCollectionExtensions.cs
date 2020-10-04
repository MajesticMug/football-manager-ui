using System;
using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;

namespace Football.Api.ServiceClient.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFootballDataApiClient(this IServiceCollection services, string baseUrl, string apiToken)
        {
            services.AddHttpClient<IServiceClient, ServiceClient>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Add("x-auth-token", apiToken);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            });

            services.AddTransient<IFootballDataApiClient, FootballDataApiClient>();

            return services;
        }
    }
}
