using HomeTheatre.Data.DbModels;
using HomeTheatre.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTheatre.Mappers
{
    public static class UserMapper
    {
        public static UserViewModel MapFromUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("No such User");
            }

            return new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                CreatedOn = user.CreatedOn,
              
            };
        }
    }
}
