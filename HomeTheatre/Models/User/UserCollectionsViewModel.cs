using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTheatre.Models.User
{
    public class UserCollectionsViewModel
    {
        public ICollection<UserViewModel> BannedUsers { get; set; }
        public ICollection<UserViewModel> ActiveUsers { get; set; }
    }
}
