using HomeTheatre.Data.Utilities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeTheatre.Data.DbModels
{
    public class User : IdentityUser<Guid>, IAuditable, IDeletable
    {
        public User()
        {
            Theatres = new List<Theatre>();
            Bans = new List<Ban>();
            Reviews = new List<Review>();
        }

        public string Name { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Theatre> Theatres { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Ban> Bans { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsBanned { get; set; }

    }
}
