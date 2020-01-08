using HomeTheatre.Models.Theatre;
using System.Collections.Generic;

namespace HomeTheatre.Models.General
{
    public class HomeViewModel
    {
        public ICollection<TheatreViewModel> SixTheatres { get; set; }
        public ICollection<TheatreViewModel> TopTheatres { get; set; }
    }
}
