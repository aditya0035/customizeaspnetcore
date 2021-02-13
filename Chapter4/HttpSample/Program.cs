using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HttpSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel(kestrelOptions =>
                    {
                        kestrelOptions.Listen(IPAddress.Loopback, 5000);
                        kestrelOptions.Listen(IPAddress.Loopback, 5001, listenOptions =>
                        {
                            listenOptions.UseHttps("certificate.pfx", "topsecret");
                        });
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
