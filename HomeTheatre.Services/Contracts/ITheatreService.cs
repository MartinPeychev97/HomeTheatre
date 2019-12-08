using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HomeTheatre.Data.DbModels;

namespace HomeTheatre.Services.Contracts
{
    public interface ITheatreService
    {
        Task<Theatre> CreateTheatreAsync(Theatre tempTheatre);
        Task<Theatre> DeleteTheatreAsync(Guid Id);
        Task<ICollection<Theatre>> GetAllTheatresAsync();
        Task<Theatre> GetTheatreAsync(Guid Id);
    }
}