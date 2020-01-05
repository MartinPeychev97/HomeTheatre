﻿using HomeTheatre.Data.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeTheatre.Data.DbModels
{
    public class Theatre : IEntityId,IDeletable,IAuditable
    {
        [Key]
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
        [Range(1, 5)]
        public int Rating { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public User User { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
