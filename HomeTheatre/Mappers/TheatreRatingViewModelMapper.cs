using HomeTheatre.Data.DbModels;
using HomeTheatre.Mappers.Contract;
using HomeTheatre.Models.Theatre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTheatre.Mappers
{
    public class TheatreRatingViewModelMapper : IViewModelMapper<Rating, TheatreRatingViewModel>
    {
        public TheatreRatingViewModel MapFrom(Rating Entity)
        {
            if (Entity == null)
            {
                throw new Exception("There is no Rating given in the parameters");
            }
            return new TheatreRatingViewModel
            {
                Value = Entity.Value,
                TheatreId = Entity.TheatreId,
                UserId = Entity.UserId,
                UserName = Entity.UserName,
                CreatedOn = Entity.CreatedOn,
                ModifiedOn = Entity.ModifiedOn,
                DeletedOn = Entity.DeletedOn,
                IsDeleted = Entity.IsDeleted
            };
        }

        public ICollection<TheatreRatingViewModel> MapFrom(ICollection<Rating> Entities)
        {
            return Entities.Select(this.MapFrom).ToList();
        }

        public Rating MapFrom(TheatreRatingViewModel entityVM)
        {
            if (entityVM == null)
            {
                throw new Exception("There was no ViewModel found");
            }
            return new Rating
            {
                Value = entityVM.Value,
                TheatreId = entityVM.TheatreId,
                UserId = entityVM.UserId,
                UserName = entityVM.UserName,
                CreatedOn = entityVM.CreatedOn,
                ModifiedOn = entityVM.ModifiedOn,
                DeletedOn = entityVM.DeletedOn,
                IsDeleted = entityVM.IsDeleted
            };
        }

        public ICollection<Rating> MapFrom(ICollection<TheatreRatingViewModel> entitiesVM)
        {
            return entitiesVM.Select(this.MapFrom).ToList();
        }
    }
}
