using HomeTheatre.Data.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTheatre.Models.Theatre
{
    public class TheatreViewModel
    {

        public Guid Id { get; set; }

        [DisplayName("Theatre Name")]
        [Required]
        [StringLength(40, ErrorMessage = "The  value cannot exceed 40 characters.")]
        public string Name { get; set; }

        [DisplayName("Theatre AboutInfo")]
        [Required]
        [StringLength(1000, ErrorMessage = "The value cannot exceed 1000 characters.")]
        public string AboutInfo { get; set; }

        public string Location { get; set; }

        public string Phone { get; set; }
        public bool IsDeleted { get; set; }
    }
}
