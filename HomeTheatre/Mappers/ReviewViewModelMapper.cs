using HomeTheatre.Data.DbModels;
using HomeTheatre.Mappers.Contract;
using HomeTheatre.Models.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTheatre.Mappers
{
    public class ReviewViewModelMapper : IViewModelMapper<Review, ReviewViewModel>
    {
        public ReviewViewModel MapFrom(Review Entity)
        {
            if (Entity == null)
            {
                throw new Exception("There is no Review given in the parameters");
            }
            return new ReviewViewModel
            {
                Id = Entity.Id,
                Author = Entity.Author,
                Rating = Entity.Rating,
                ReviewText = Entity.ReviewText,
                CreatedOn = Entity.CreatedOn,
                //UserId=Entity.UserId,
                ModifiedOn = Entity.ModifiedOn,
                DeletedOn = Entity.DeletedOn,
                IsDeleted = Entity.IsDeleted
            };
        }
        public Review MapFrom(ReviewViewModel entityVM)
        {
            if (entityVM == null)
            {
                throw new Exception("There was no ViewModel found");
            }
            return new Review
            {
                Id = entityVM.Id,
                Author = entityVM.Author,
                Rating = entityVM.Rating,
                ReviewText = entityVM.ReviewText,
                CreatedOn = entityVM.CreatedOn,
                //UserId = entityVM.UserId,
                ModifiedOn = entityVM.ModifiedOn,
                DeletedOn = entityVM.DeletedOn,
                IsDeleted = entityVM.IsDeleted,
                TheatreId = entityVM.TheatreId
            };
        }
        public ICollection<ReviewViewModel> MapFrom(ICollection<Review> Entities)
        {
            return Entities.Select(MapFrom).ToList();
        }
       
        public ICollection<Review> MapFrom(ICollection<ReviewViewModel> entitiesVM)
        {
            return entitiesVM.Select(MapFrom).ToList();
        }

    }
}

