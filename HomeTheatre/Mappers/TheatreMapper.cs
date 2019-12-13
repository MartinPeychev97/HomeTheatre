using HomeTheatre.Data.DbModels;
using HomeTheatre.Models.Theatre;
using HomeTheatre.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTheatre.Mappers
{
    public static class TheatreMapper
    {
        public static TheatreViewModel MapFromTheatre(this Theatre theatre)
        {
            if (theatre == null)
            {
                throw new ArgumentNullException();
            }
            var theatreListing = new TheatreViewModel
            {
                Id = theatre.Id,
                Name = theatre.Name,
                AboutInfo = theatre.AboutInfo,
                Phone = theatre.Phone,
                Location = theatre.Location,

            };
            return theatreListing;
        }
      
    }
}
