using HomeTheatre.Data.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeTheatre.Data.DbModels
{
    public class Theatre : IEntityId
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string AboutInfo { get; set; }

        public string Location { get; set; }

        public DateTime CreatedOn { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public User User { get; set; }
    }
}
