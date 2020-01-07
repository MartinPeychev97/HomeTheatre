using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HomeTheatre.Data.DbModels;

namespace HomeTheatre.Services.Contracts
{
    public interface IReviewServices
    {
        Task<Review> CreateReviewAsync(Review tempReview);
        Task<Review> DeleteReviewAsync(Guid id);
        Task<Review> EditReviewAsync(Guid id, string newReviewText);
        Task<Review> GetReviewAsync(Guid id);
        Task<ICollection<Review>> GetAllReviewsAsync(Guid id);
    }
}