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
            if (Entity == null)
            {
                throw new Exception("There is no User in the parameters given");
            }
            return new UserViewModel
            {
                Id = Entity.Id,
                Name = Entity.Name,
                PhoneNumber = Entity.PhoneNumber,
                CreatedOn = Entity.CreatedOn,
                ModifiedOn = Entity.ModifiedOn,
                DeletedOn = Entity.DeletedOn,
                IsDeleted = Entity.IsDeleted,
                Role = Entity.Role,
                RoleName=Entity.RoleName,
                Email = Entity.Email,
                IsBanned = Entity.IsBanned,
                BanReason= Entity.BanReason
            };
        }

        public ICollection<UserViewModel> MapFrom(ICollection<User> Entities)
        {
            return Entities.Select(MapFrom).ToList();
        }

        public User MapFrom(UserViewModel entityVM)
        {
            if (entityVM == null)
            {
                throw new Exception("There was no ViewModel found");
            }
            return new User
            {
                Id = entityVM.Id,
                Name = entityVM.Name,
                PhoneNumber = entityVM.PhoneNumber,
                CreatedOn = entityVM.CreatedOn,
                ModifiedOn = entityVM.ModifiedOn,
                DeletedOn = entityVM.DeletedOn,
                IsDeleted = entityVM.IsDeleted,
                Role = entityVM.Role,
                RoleName= entityVM.RoleName,
                Email = entityVM.Email,
                IsBanned = entityVM.IsBanned,
                BanReason = entityVM.BanReason
            };
        }

        public ICollection<User> MapFrom(ICollection<UserViewModel> entitiesVM)
        {
            return entitiesVM.Select(MapFrom).ToList();
        }
    }
}
