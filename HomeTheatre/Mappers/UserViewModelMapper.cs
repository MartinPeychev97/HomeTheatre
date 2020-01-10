using HomeTheatre.Data.DbModels;
using HomeTheatre.Mappers.Contract;
using HomeTheatre.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTheatre.Mappers
{
    public class UserViewModelMapper : IViewModelMapper<User, UserViewModel>
    {
        public UserViewModel MapFrom(User Entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<UserViewModel> MapFrom(ICollection<User> Entities)
        {
            throw new NotImplementedException();
        }

        public User MapFrom(UserViewModel entityVM)
        {
            throw new NotImplementedException();
        }

        public ICollection<User> MapFrom(ICollection<UserViewModel> entitiesVM)
        {
            throw new NotImplementedException();
        }
    }
}
