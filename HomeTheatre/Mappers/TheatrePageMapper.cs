using HomeTheatre.Models.Theatre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTheatre.Mappers
{
    public static class TheatrePageMapper
    {
        public static TheatreIndexViewModel MapFromEmailIndex(this ICollection<TheatreViewModel> theatres, int currentPage, int totalPages)
        {
            var model = new TheatreIndexViewModel
            {
                CurrPage = currentPage,
                TotalPages = totalPages,
                TheatreModels = theatres
            };

            return model;
        }
    }
}
