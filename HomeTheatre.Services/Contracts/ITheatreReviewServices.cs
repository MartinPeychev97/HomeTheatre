using HomeTheatre.Data.DbModels;
using System;
using System.Threading.Tasks;

namespace HomeTheatre.Services.Services
{
    public interface ITheatreReviewServices
    {
        Task<TheatreReview> GetTheatreReviewAsync(Guid theatreReviewId);
        Task<Theatre> AddReviewAsync(Theatre theatreParam, Review reviewParam);
        Task<TheatreReview> RemoveReviewAsync(TheatreReview theatreReviewParams);
    }
}