using System;
using System.Threading.Tasks;
using Football.Api.Exceptions.Base;
using Football.Api.ResponseModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Football.Api.Exceptions.Middleware
{
    internal class ApiExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiExceptionMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ApiException apiException)
            {
                if (context.Response.HasStarted)
                {
                    throw;
                }

                context.Response.Clear();
                context.Response.StatusCode = (int) apiException.GetStatusCode();
                context.Response.ContentType = @"application/json";

                await context.Response.WriteAsync(JsonConvert.SerializeObject(new MessageResponse
                {
                    Message = apiException.Message
                }));
            }
        }
    }

    internal static class ApiExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseBusinessExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiExceptionMiddleware>();
        }
    }
}
