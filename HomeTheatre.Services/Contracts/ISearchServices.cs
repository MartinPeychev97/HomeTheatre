using HomeTheatre.Services.Utility;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeTheatre.Services.Contracts
{
    public interface ISearchServices
    {
        Task<ICollection<SearchTheatre>> SearchAsync(string searchCriteria, bool byName, bool ByLocation, bool byRating, double ratingValue);
    }
}