using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HomeTheatre.Data.DbModels;
using HomeTheatre.Services.Utility;

namespace HomeTheatre.Services.Contracts
{
    public interface ITheatreService
    {
        Task<Theatre> CreateTheatreAsync(Theatre tempTheatre);
        Task<Theatre> DeleteTheatreAsync(Guid Id);
        Task<ICollection<Theatre>> GetAllTheatresAsync();
        Task<Theatre> GetTheatreAsync(Guid Id);
        Task<int> GetPageCountAsync(int theatresPerPage);
        Task<ICollection<Theatre>> GetSixTheatresAsync(int currentPage, string sortOrder);
        Task<Theatre> UpdateAsync(Guid id, string newName, string newAboutInfo, string newLocattion, string newPhone);
        Task<Theatre> GetAverageRatingAndNumberOfReviews(Guid theatreId);
        Task<ICollection<Theatre>> GetTopTheatresAsync(int num);
    }
}