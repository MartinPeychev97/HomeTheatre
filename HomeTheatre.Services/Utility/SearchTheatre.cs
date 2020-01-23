using System;
using System.Collections.Generic;
using System.Text;

namespace HomeTheatre.Services.Utility
{
    public class SearchTheatre
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public double? AverageRating { get; set; }

        public string Phone { get; set; }
    }
}
