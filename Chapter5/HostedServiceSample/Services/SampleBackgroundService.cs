using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
namespace HostedServiceSample.Services
{
    public class SampleBackgroundService : BackgroundService
    {
        private readonly ILogger<SampleBackgroundService> _logger;

        public SampleBackgroundService(ILogger<SampleBackgroundService> logger)
        {
            _logger = logger;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Background Service Starting");
            return Task.Factory.StartNew(async () =>
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation($"Background Service Executing - {DateTime.Now}");
                    await Task.Delay(TimeSpan.FromSeconds(2));
                }    
            });
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Background Service Stopped");
            return Task.CompletedTask;
        }
    }
}
