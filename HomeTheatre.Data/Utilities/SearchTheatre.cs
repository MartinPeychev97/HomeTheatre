using System;
using System.Collections.Generic;
using System.Text;

namespace HomeTheatre.Data.Utilities
{
   public class SearchTheatre
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string ImagePath { get; set; }
        public double? AverageRating { get; set; }
    }
}
