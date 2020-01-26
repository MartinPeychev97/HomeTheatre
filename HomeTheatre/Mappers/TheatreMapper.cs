using HomeTheatre.Data.DbModels;
using HomeTheatre.Models.Theatre;
using System.Collections.Generic;

namespace HomeTheatre.Mappers
{
    public static class TheatreMapper
    {
        public static TheatreViewModel MapFromTheatre(this Theatre theatre)
        {
            var theatreListing = new TheatreViewModel
            {
                Id = theatre.Id,
                Name = theatre.Name,
                AboutInfo = theatre.AboutInfo,
                Phone = theatre.Phone,
                Location = theatre.Location,
                CreatedOn = theatre.CreatedOn,
                ModifiedOn = theatre.ModifiedOn,
                DeletedOn = theatre.DeletedOn,
                IsDeleted = theatre.IsDeleted
            };

            return theatreListing;
        }

        public static TheatreIndexViewModel MapFromTheatreIndex(this ICollection<TheatreViewModel> theatre)
        {
            var model = new TheatreIndexViewModel
            {
                TheatreModels = theatre
            };

            return model;
        }
    }
}
