using System;
using System.Collections.Generic;
using System.Text;

namespace HomeTheatre.Data.Utilities
{
   public interface IAuditable
    {
        DateTime CreatedOn { get; set; }
        DateTime? ModifiedOn { get; set; }
    }
}
