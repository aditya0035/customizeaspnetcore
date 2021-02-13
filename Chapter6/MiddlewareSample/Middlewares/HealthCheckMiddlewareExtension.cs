using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareSample.Middlewares
{
    //public static class HealthCheckMiddlewareExtension
    //{
    //    public static IApplicationBuilder UseHealthCheckCore(this IApplicationBuilder app,string path,int? Port,object [] args)
    //    {
    //        if (Port == null)
    //        {
    //            app.Map(path, b => b.UseMiddleware<HealthCheckMiddleare>(agrs));
    //        }
    //        else
    //        {
    //            app.MapWhen(c => c.Connection.LocalPort == Port,
    //                b0 => b0.Map(path, b1 => b1.UseMiddleware<HealthCheckMiddleare>(args)));
    //        }
    //    }
    //}
}
