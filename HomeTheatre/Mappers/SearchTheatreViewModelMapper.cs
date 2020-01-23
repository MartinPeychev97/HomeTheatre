using HomeTheatre.Mappers.Contract;
using HomeTheatre.Models.General;
using HomeTheatre.Models.Theatre;
using HomeTheatre.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTheatre.Mappers
{
    public class SearchTheatreViewModelMapper : IViewModelMapper<SearchTheatre, TheatreViewModel>
    {
        public TheatreViewModel MapFrom(SearchTheatre Entity)
        {
            if (Entity == null)
            {
                throw new Exception("There is no object given in the parameters");
            }
            return new TheatreViewModel
            {
               Id=Entity.Id,
               Name=Entity.Name,
               Location=Entity.Location,
               AverageRating=Entity.AverageRating,
               Phone=Entity.Phone
            };
        }

        public ICollection<TheatreViewModel> MapFrom(ICollection<SearchTheatre> Entities)
        {
            return Entities.Select(MapFrom).ToList();
        }

        public SearchTheatre MapFrom(TheatreViewModel entityVM)
        {
            if (entityVM == null)
            {
                throw new Exception("There was no ViewModel found");
            }
            return new SearchTheatre
            {
                Id = entityVM.Id,
                Name = entityVM.Name,
                Location = entityVM.Location,
                AverageRating = entityVM.AverageRating,
                Phone = entityVM.Phone

            };
        }

        public ICollection<SearchTheatre> MapFrom(ICollection<TheatreViewModel> entitiesVM)
        {
            return entitiesVM.Select(MapFrom).ToList();
        }
    }
}
