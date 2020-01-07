using HomeTheatre.Data.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTheatre.Models.Review
{
    public class ReviewViewModel : IEntityId, IAuditable, IDeletable
    {
        public Guid Id { get; set; }
        public string Author { get; set; }
        public int Rating { get; set; }
        [MaxLength(500, ErrorMessage = "Text cannot exceed 500 characters")]
        public string ReviewText { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
