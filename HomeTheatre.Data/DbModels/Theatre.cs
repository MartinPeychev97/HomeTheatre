﻿using HomeTheatre.Data.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HomeTheatre.Data.DbModels
{
    public class Theatre : IEntityId, IDeletable, IAuditable
    {
        public Theatre()
        {
            Reviews = new List<Review>();
            AverageRating = 0.00;
        }

        [Key]
        public Guid Id { get; set; }

        [DisplayName("Theatre Name")]
        [Required]
        [StringLength(40, ErrorMessage = "The  value cannot exceed 40 characters.")]
        public string Name { get; set; }
        [Required]
        public double? AverageRating { get; set; }
        [Required]
        public int NumberOfReviews { get; set; }

        [DisplayName("Theatre AboutInfo")]
        [Required]
        [StringLength(1000, ErrorMessage = "The value cannot exceed 1000 characters.")]
        public string AboutInfo { get; set; }

        public string Location { get; set; }
        public string Phone { get; set; }
        public string ImagePath { get; set; }
        public string Image { get; set; }
        public double? CurrentUserRating { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public User User { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
