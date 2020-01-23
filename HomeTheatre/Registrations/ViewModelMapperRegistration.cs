using HomeTheatre.Areas.Administrator.Models;
using HomeTheatre.Data.DbModels;
using HomeTheatre.Mappers;
using HomeTheatre.Mappers.Contract;
using HomeTheatre.Models.Comment;
using HomeTheatre.Models.Review;
using HomeTheatre.Models.Theatre;
using HomeTheatre.Models.User;
using HomeTheatre.Services.Utility;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTheatre.Registrations
{
    public static class ViewModelMapperRegistration
    {
        public static IServiceCollection AddCustomViewModelMappers(this IServiceCollection services)
        {
            services.AddSingleton<IViewModelMapper<Theatre, TheatreViewModel>, TheatreViewModelMapper>();

            services.AddSingleton<IViewModelMapper<User, UserViewModel>, UserViewModelMapper>();

            services.AddSingleton<IViewModelMapper<SearchTheatre, TheatreViewModel>, SearchTheatreViewModelMapper>();

            services.AddSingleton<IViewModelMapper<Review, ReviewViewModel>, ReviewViewModelMapper>();

            services.AddSingleton<IViewModelMapper<Comment, CommentViewModel>, CommentViewModelMapper>();


            return services;
        }

    }
}
