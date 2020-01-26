using HomeTheatre.Data.DbModels;
using HomeTheatre.Models.User;
using HomeTheatre.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTheatre.Mappers
{
    public static class UserMapper
    {
        public static UserViewModel MapFromUser(this User user, IUserServices userService)
        {
            var emailListing = new UserViewModel
            {
                Name = user.Name,
                Role = user.Role,
                Email = user.Email,
                Id = user.Id,
                PhoneNumber = user.PhoneNumber,
            };

            return emailListing;
        }

        public static UserIndexViewModel MapFromUserIndex(this IEnumerable<UserViewModel> user, int currentPage, int totalPages)
        {
            var model = new UserIndexViewModel
            {
                CurrentPage = currentPage,
                TotalPages = totalPages,
                Users = user
            };

            return model;
        }
    }
}
