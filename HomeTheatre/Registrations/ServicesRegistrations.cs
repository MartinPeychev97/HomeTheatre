using HomeTheatre.Services.Contracts;
using HomeTheatre.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTheatre.Registrations
{
    public static class ServicesRegistrations
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICommentServices, CommentServices>();
            services.AddScoped<IReviewServices, ReviewServices>();
            services.AddScoped<ITheatreService, TheatreService>();
            services.AddScoped<IBanServices, BanServices>();
            services.AddScoped<ITheatreReviewServices, TheatreReviewServices>();
           // services.AddScoped<ISearchServices, SearchServices>();

            return services;
        }
    }
}
