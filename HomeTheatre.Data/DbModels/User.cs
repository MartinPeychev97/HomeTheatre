using HomeTheatre.Data.Utilities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeTheatre.Data.DbModels
{
    public class User : IdentityUser, IAuditable, IDeletable
    {

        public string Name { get; set; }

        public ICollection<Theatre> Theatres { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
