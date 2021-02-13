using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConfigurationSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostBuilderContext,configureationBuilder)=> {
                    configureationBuilder.SetBasePath(hostBuilderContext.HostingEnvironment.ContentRootPath);
                    configureationBuilder.AddJsonFile("appsettings.json", false, true);
                    configureationBuilder.AddJsonFile($"appsettings.{hostBuilderContext.HostingEnvironment.EnvironmentName}.json",true,true);
                    configureationBuilder.AddEnvironmentVariables();
                    configureationBuilder.AddCommandLine(args);
                    //var paymentsEventStore = configureRoot.GetSection("ConnectionStrings").GetSection("PaymentsEventStore").Value;
                    //configureationBuilder.Add(new DatabaseConfigurationSource(paymentsEventStore));  
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                });
    }
}
