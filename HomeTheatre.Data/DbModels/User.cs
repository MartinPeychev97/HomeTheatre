using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeTheatre.Data.DbModels
{
    public class User : IdentityUser
    {

        public string Name { get; set; }

        public ICollection<Theatre> Theatres { get; set; }
        public ICollection<Review> Reviews { get; set; }



    }
}
