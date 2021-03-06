﻿using HomeTheatre.Models.Theatre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTheatre.Models.General
{
    public class SearchTheatreViewModel
    {
        public string SearchName { get; set; }
        public bool SearchByName { get; set; }
        public bool SearchByLocation { get; set; }
        public bool SearchByRating { get; set; }
        public double RatingValue { get; set; }

        public IReadOnlyCollection<TheatreViewModel> SearchResults { get; set; } = new List<TheatreViewModel>();
    }
}
