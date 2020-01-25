using HomeTheatre.Data.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTheatre.Models.Comment
{
    public class CommentViewModel : IEntityId, IAuditable, IDeletable
    {
        public Guid Id { get; set; }
        public Guid ReviewId { get; set; }
        public Guid UserId { get; set; }
        public string Author { get; set; }
        [DisplayName("Comment Text")]
        [Required]
        [StringLength(300, ErrorMessage = "Body Lenght must be between 2 and 300 characters", MinimumLength = 2)]
        public string CommentText { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
