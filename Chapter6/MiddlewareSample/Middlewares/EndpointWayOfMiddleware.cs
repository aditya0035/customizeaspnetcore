using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace MiddlewareSample.Middlewares
{
    public class AppStatusMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _status;

        public AppStatusMiddleware(RequestDelegate next,string status)
        {
            this._next = next;
            this._status = status;
        }
        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync($"Hello {_status}");
        }
    }

    public static class MapAppStatusMiddlewareExtension
    {
        public static IEndpointConventionBuilder MapAppStatus(this IEndpointRouteBuilder routes,string pattern,string name = "World!")
        {
            var pipeline = routes.CreateApplicationBuilder().UseMiddleware<AppStatusMiddleware>(name).Build();
            return routes.Map(pattern, pipeline).WithDisplayName("AppStatusMiddleware");
        }
    }
}
