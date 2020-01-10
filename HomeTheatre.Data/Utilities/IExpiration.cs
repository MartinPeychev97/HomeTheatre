using System;
using System.Collections.Generic;
using System.Text;

namespace HomeTheatre.Data.Utilities
{
   public interface IExpiration
    {
        DateTime ExpiresOn { get; set; }
        bool HasExpired { get; set; }
    }
}
