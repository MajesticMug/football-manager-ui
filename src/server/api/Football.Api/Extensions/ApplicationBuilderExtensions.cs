using Football.Api.Exceptions.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Football.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseFootballApi(this IApplicationBuilder builder)
        {
            return builder.UseBusinessExceptionMiddleware();
        }
    }
}
