using HomeTheatre.Areas.Administrator.Models;
using HomeTheatre.Data.DbModels;
using HomeTheatre.Mappers.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTheatre.Mappers
{
    public class TheatreReviewViewModelMapper : IViewModelMapper<TheatreReview, TheatreReviewViewModel>
    {
        public TheatreReviewViewModel MapFrom(TheatreReview Entity)
        {
            if (Entity == null)
            {
                throw new Exception("There is no TheatreReview given in the parameters");
            }
            return new TheatreReviewViewModel
            {
                Id=Entity.Id,
                Theatre = Entity.Theatre,
                TheatreId = Entity.TheatreId,
                Review = Entity.Review,
                ReviewId = Entity.ReviewId,
                CreatedOn = Entity.CreatedOn,
                ModifiedOn = Entity.ModifiedOn,
                DeletedOn = Entity.DeletedOn,
                IsDeleted = Entity.IsDeleted
            };
        }

        public ICollection<TheatreReviewViewModel> MapFrom(ICollection<TheatreReview> Entities)
        {
            return Entities.Select(MapFrom).ToList();
        }

        public TheatreReview MapFrom(TheatreReviewViewModel entityVM)
        {
            if (entityVM == null)
            {
                throw new Exception("There was no ViewModel found");
            }
            return new TheatreReview
            {
                Id = entityVM.Id,
                Theatre = entityVM.Theatre,
                TheatreId = entityVM.TheatreId,
                Review = entityVM.Review,
                ReviewId = entityVM.ReviewId,
                CreatedOn = entityVM.CreatedOn,
                ModifiedOn = entityVM.ModifiedOn,
                DeletedOn = entityVM.DeletedOn,
                IsDeleted = entityVM.IsDeleted
            };
        }

        public ICollection<TheatreReview> MapFrom(ICollection<TheatreReviewViewModel> entitiesVM)
        {
            return entitiesVM.Select(MapFrom).ToList();
        }
    }
}
