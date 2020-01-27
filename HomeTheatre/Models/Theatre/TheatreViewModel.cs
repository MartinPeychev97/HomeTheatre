using HomeTheatre.Data.Utilities;
using HomeTheatre.Models.Comment;
using HomeTheatre.Models.Review;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HomeTheatre.Models.Theatre
{
    public class TheatreViewModel : IEntityId, IAuditable, IDeletable
    {
        public TheatreViewModel()
        {
            ReviewsVM = new List<ReviewViewModel>();
        }

        public Guid Id { get; set; }

        [DisplayName("Theatre Name")]
        [Required]
        [StringLength(40, ErrorMessage = "The value cannot exceed 40 characters.")]
        public string Name { get; set; }

        [DisplayName("Theatre AboutInfo")]
        [Required]
        [StringLength(1000, ErrorMessage = "The value cannot exceed 1000 characters.")]
        public string AboutInfo { get; set; }

        [Required]
        public int NumberOfReviews { get; set; }

        [Required]
        public double? AverageRating { get; set; }
        public string ImagePath { get; set; }
        public string Image { get; set; }
        public string Location { get; set; }

        [Required]
        public string Phone { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }

        public ICollection<ReviewViewModel> ReviewsVM { get; set; }
        public ICollection<CommentViewModel> CommentsVM { get; set; }
        public double? CurrentUserRating { get; set; }
    }
}
