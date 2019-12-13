using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTheatre.Models.Theatre
{
    public class TheatreIndexViewModel
    {
        public ICollection<TheatreViewModel> TheatreModels { get; set; }
        public int? PrevPage { get; set; }

        public int CurrPage { get; set; }

        public int? NextPage { get; set; }

        public int TotalPages { get; set; }
    }
}
