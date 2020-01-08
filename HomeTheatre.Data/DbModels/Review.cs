using HomeTheatre.Data.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeTheatre.Data.DbModels
{
    public class Review : IEntityId, IDeletable, IAuditable
    {
        [Key]
        public Guid Id { get; set; }
        public string Author { get; set; }
        [Range(1, 5)]
        public double Rating { get; set; }
        [MaxLength(500, ErrorMessage = "Text cannot exceed 500 characters")]
        public string ReviewText { get; set; }
        public Theatre Theatre { get; set; }
        public Guid TheatreId { get; set; }
        public User User { get; set; }
        public DateTime DateReviewed { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
