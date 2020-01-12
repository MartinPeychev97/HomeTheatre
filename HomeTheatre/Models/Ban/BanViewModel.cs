using HomeTheatre.Data.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTheatre.Models.Ban
{
    public class BanViewModel : IEntityId
    {
        public Guid Id { get; set; }
        [MaxLength(100, ErrorMessage = "You must include a description for the ban which is between 100 and 2 characters"), MinLength(2)]
        public string BanReason { get; set; }

        [Range(1, 365)]
        public int DurationInDays { get; set; }
    }
}
