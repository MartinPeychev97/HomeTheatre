using HomeTheatre.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTheatre.Registrations
{
    public static class HostedServicesRegistration
    {
        public static IServiceCollection AddHostedServices(this IServiceCollection services)
        {
            services.AddHostedService<HostedUnbanServices>();

            return services;
        }
    }
}
