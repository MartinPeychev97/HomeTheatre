using HomeTheatre.Data.DbModels;
using HomeTheatre.Data.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTheatre.Models.User
{
    public class UserViewModel : IEntityId, IAuditable, IDeletable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public Role Role { get; set; }
        public string RoleName { get; set; }
        public bool IsBanned { get; set; }
        public string BanReason { get; set; }
    }
}
