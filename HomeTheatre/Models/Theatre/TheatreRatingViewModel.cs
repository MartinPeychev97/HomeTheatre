using HomeTheatre.Data.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTheatre.Models.Theatre
{
    public class TheatreRatingViewModel : IAuditable, IDeletable
    {
        [Required]
        [Range(1, 5)]
        public double Value { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public Guid TheatreId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
