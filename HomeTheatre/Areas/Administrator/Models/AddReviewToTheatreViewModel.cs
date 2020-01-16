using HomeTheatre.Data.DbModels;
using HomeTheatre.Data.Utilities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTheatre.Areas.Administrator.Models
{
    public class AddReviewToTheatreViewModel : IEntityId
    {
        public Guid Id { get; set; }
        public List<Review> AllReviews { get; set; }
        public List<string> SelectedReviews { get; set; }

    }
}
