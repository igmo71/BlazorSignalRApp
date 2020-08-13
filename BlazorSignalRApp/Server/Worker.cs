using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlazorSignalRApp.Server.Hubs;
using BlazorSignalRApp.Shared;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BlazorSignalRApp.Server
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHubContext<ClockHub, IClock> _clockHub;
        private readonly IHubContext<TimeHub> _timeHub;

        public Worker(ILogger<Worker> logger, IHubContext<ClockHub, IClock> clockHub, IHubContext<TimeHub> timeHub)
        {
            _logger = logger;
            _clockHub = clockHub;
            _timeHub = timeHub;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                DateTime dateTime = DateTime.Now;
                await _clockHub.Clients.All.ShowTime(dateTime);
                await _timeHub.Clients.All.SendAsync("ShowTime", dateTime);

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
