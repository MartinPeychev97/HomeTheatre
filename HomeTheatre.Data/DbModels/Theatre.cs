using HomeTheatre.Data.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeTheatre.Data.DbModels
{
    public class Theatre : IEntityId,IDeletable,IAuditable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

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
