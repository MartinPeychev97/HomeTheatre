using HomeTheatre.Data.DbModels;
using System;
using System.Threading.Tasks;

namespace HomeTheatre.Services.Contracts
{
    public interface ITheatreReviewServices
    {
        Task<Theatre> AddReviewAsync(Theatre theatreTemp, Review reviewTemp);
        Task<Theatre> RemoveReviewAsync(Theatre theatreTemp, Review reviewTemp);
    }
}