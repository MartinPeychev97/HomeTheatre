using HomeTheatre.Data.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeTheatre.Data.DbModels
{
    public class Ban : IEntityId,IExpiration
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string ReasonBanned { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public DateTime ExpiresOn { get; set; }
        public bool HasExpired { get; set; }

    }
}
