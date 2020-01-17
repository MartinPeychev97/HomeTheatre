using HomeTheatre.Data.DbModels;
using HomeTheatre.Data.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeTheatre.Areas.Administrator.Models
{
    public class TheatreReviewViewModel:IEntityId,IAuditable,IDeletable
    {
        public Guid Id { get; set; }
        public Theatre Theatre { get; set; }
        public Guid TheatreId { get; set; }
        public Review Review { get; set; }
        public Guid ReviewId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
