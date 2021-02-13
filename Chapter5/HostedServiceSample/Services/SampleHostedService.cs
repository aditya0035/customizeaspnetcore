using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace HostedServiceSample.Services
{
    public class SampleHostedService : IHostedService
    {
        private readonly ILogger<SampleHostedService> _logger;

        public SampleHostedService(ILogger<SampleHostedService> logger)
        {
            _logger = logger;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Hosted Service starting");
            return Task.Factory.StartNew(async () =>
            {
                //loop until cancellation requested
                while (!cancellationToken.IsCancellationRequested)
                {
                    _logger.LogInformation($"Hosted Service Executing - {DateTime.Now}");
                    try
                    {
                        await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
                    }
                    catch (OperationCanceledException)
                    {
                    }
                }
            },cancellationToken, TaskCreationOptions.LongRunning,TaskScheduler.Default);
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Hosted service stopping");
            return Task.CompletedTask;
        }
    }
}
