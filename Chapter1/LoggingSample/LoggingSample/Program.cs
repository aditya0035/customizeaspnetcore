using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
namespace LoggingSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging((hostBuilderContext,logging) => {
                    var coloredConsoleConfiguration = new ColoredConsoleConfiguration();
                    logging.ClearProviders();
                    logging.AddConfiguration(hostBuilderContext.Configuration.GetSection("logging"));
                    logging.AddProvider(new ColoredConsoleLoggerProvider(coloredConsoleConfiguration));
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                });
    }
}
