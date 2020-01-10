using HomeTheatre.Data.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeTheatre.Data.DbModels
{
    public class Theatre : IEntityId,IDeletable,IAuditable
    {
        public Theatre()
        {
            Reviews = new List<Review>();
        }

        [Key]
        public Guid Id { get; set; }
        [DisplayName("Theatre Name")]
        [Required]
        [StringLength(40, ErrorMessage = "The  value cannot exceed 40 characters.")]
        public string Name { get; set; }
        public double? AverageRating { get; set; }
        public int NumberOfReviews { get { return Reviews.Count; } set { NumberOfReviews = value; } }
        [DisplayName("Theatre AboutInfo")]
        [Required]
        [StringLength(1000, ErrorMessage = "The value cannot exceed 1000 characters.")]
        public string AboutInfo { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public User User { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
