using System;
using System.Collections.Generic;
using System.Text;

namespace HomeTheatre.Services.Utility
{
    public static class SearchExtention
    {
        public static bool Contains(this string target, string[] terms)
        {
            foreach (var term in terms)
            {
                if (target.Contains(term, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
