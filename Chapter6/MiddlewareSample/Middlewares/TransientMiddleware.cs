using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareSample.Middlewares
{
    public class TransientMiddleware: IMiddleware
    {
        private readonly ILogger<TransientMiddleware> logger;

        public TransientMiddleware(ILogger<TransientMiddleware> logger)
        {
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var s = new Stopwatch();
            s.Start();
            await next(context);
            s.Stop();
            var result = s.ElapsedMilliseconds;
            await context.Response.WriteAsync($"TIme Needed:{result}");
        }
    }
    public static class StopwatchTransientExtension
    {
        public static IApplicationBuilder UseStopWatch(this IApplicationBuilder app)
        {
            app.UseMiddleware<TransientMiddleware>();
            return app;
        }
    }
}
