using HomeTheatre.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeTheatre.Services.Services
{
    public class HostedUnbanServices : IHostedService
    {
        private readonly IServiceProvider serviceProvider;
        private Timer timer;

        public HostedUnbanServices(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            this.timer = new Timer(UnbanService, null, TimeSpan.Zero,
                TimeSpan.FromMinutes(30));

            return Task.CompletedTask;
        }

        private  void UnbanService(object state)
        {
            using (var scope = this.serviceProvider.CreateScope())
            {
                var banService = scope.ServiceProvider.GetRequiredService<IBanServices>();

                //await banService.CheckForExpiredBansAsync();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            this.timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }
    }
}
