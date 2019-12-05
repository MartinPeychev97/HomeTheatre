using HomeTheatre.Data.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeTheatre.Data.DbModels
{
    public class Review : IEntityId
    {
        public string Id { get; set; }
        public Theatre Theatre { get; set; }

        public string Author { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public string ReviewText { get; set; }

        public DateTime DateReviewed { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public User User { get; set; }
    }
}
