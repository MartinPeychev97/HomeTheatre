using System;
using System.Collections.Generic;
using System.Text;

namespace HomeTheatre.Data.Utilities
{
   public interface IDeletable
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedOn { get; set; }
    }
}
