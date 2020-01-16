using HomeTheatre.Data.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeTheatre.Data.DbModels
{
    public class Rating : IAuditable, IDeletable
    {
        public double? Value { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public Theatre Theatre { get; set; }
        public Guid TheatreId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
