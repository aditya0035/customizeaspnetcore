using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MiddlewareSample.Middlewares;

namespace MiddlewareSample
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMiddleware,TransientMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /* Part 5 Branching with Map

            app.Map("/map1", (app1) =>
            {
                app1.Run(async context =>
                {
                    await context.Response.WriteAsync("Map Test 1");
                });
            });

            app.Map("/map2", (app2) =>
            {
                app2.Run(async context =>
                {
                    await context.Response.WriteAsync("Map Test 2");
                });
            });

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello World!");
            });

            */
            /* Part 6 Conditional Map route

            app.MapWhen((context) =>
            {
                return context.Request.Query.ContainsKey("branch");
            }, (app1) =>
            {
                app1.Run(async context =>
                {
                    await context.Response.WriteAsync("MapBranch Test");
                });
            });
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from non-map delegate");
            });
            */

            //app.Use(async (context, next) =>
            //{
            //    var s = new Stopwatch();
            //    s.Start();
            //    await next();
            //    s.Stop();
            //    await context.Response.WriteAsync($"Time Added:{s.ElapsedMilliseconds}");
            //});

            /* Part 3
            //app.UseStopWatch();
            */
            /* Part 4
            //app.UseTransientStopWatch();
            */

            /*Part 2
            app.Use(async (context,next) => {
                await context.Response.WriteAsync("===");
                await next();
                await context.Response.WriteAsync("===");
            });
            app.Use(async (context, next) => {
                await context.Response.WriteAsync(">>>>>>");
                await next();
                await context.Response.WriteAsync("<<<<<<");
            });
              app.Run(async context =>
            {
                await context.Response.WriteAsync(" Hello World! ");
            });
            */


            /* Part 1
            app.Run(async context =>
            {
                await context.Response.WriteAsync(" Hello World! ");
            });
            */

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAppStatus("/status");
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
        }
    }
}
