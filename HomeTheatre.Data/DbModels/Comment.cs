using HomeTheatre.Data.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeTheatre.Data.DbModels
{
    public class Comment : IEntityId,IDeletable,IAuditable
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Text cannot exceed 500 characters")]
        public string CommentText { get; set; }

        public string Author { get; set; }

        public DateTime CommentedOn { get; set; }
        public User User { get; set; }
        public Review Review { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
