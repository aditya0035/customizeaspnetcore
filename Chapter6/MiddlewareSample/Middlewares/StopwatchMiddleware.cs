using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using Microsoft.AspNetCore.Builder;

namespace MiddlewareSample.Middlewares
{
    public class StopwatchMiddleware
    {
        private readonly RequestDelegate _next;

        public StopwatchMiddleware(RequestDelegate next)
        {
                _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var s = new Stopwatch();
            s.Start();
            await _next(context);
            s.Stop();
            var result = s.ElapsedMilliseconds;
            await context.Response.WriteAsync($"TIme Needed:{result}");
        }
    }

    public static class StopwatchExtension
    {
        public static IApplicationBuilder UseTransientStopWatch(this IApplicationBuilder app)
        {
            app.UseMiddleware<StopwatchMiddleware>();
            return app;
        }
    }
}
