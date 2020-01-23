using HomeTheatre.Data;
using HomeTheatre.Data.DbModels;
using HomeTheatre.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTheatre.Services.Services
{
    public class TheatreReviewServices : ITheatreReviewServices
    {
        private readonly TheatreContext _context;

        public TheatreReviewServices(TheatreContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Theatre> AddReviewAsync(Theatre theatreTemp, Review reviewTemp)
        {
            var theatre = await _context.Theatres.Where(t => t.IsDeleted == false)
                .FirstOrDefaultAsync(t => t.Id == theatreTemp.Id);

            if (theatre == null)
            {
                throw new Exception("There was no theatre found");
            }
            var review = await _context.Reviews.Where(c => c.IsDeleted == false)
                .FirstOrDefaultAsync(r => r.Id == reviewTemp.Id);
            if (review == null)
            {
                throw new Exception("There was no review found");
            }

            theatre.Reviews.Add(review);

            await _context.SaveChangesAsync();
            return theatre;
        }

        public async Task<Theatre> RemoveReviewAsync(Theatre theatreTemp, Review reviewTemp)
        {
            var theatre = await _context.Theatres.Where(t => t.IsDeleted == false)
                .FirstOrDefaultAsync(t => t.Id == theatreTemp.Id);

            if (theatre == null)
            {
                throw new Exception("There was no theatre found");
            }
            var review = await _context.Reviews.Where(c => c.IsDeleted == false)
                .FirstOrDefaultAsync(r => r.Id == reviewTemp.Id);
            if (review == null)
            {
                throw new Exception("There was no review found");
            }

            review.IsDeleted = true;
            review.DeletedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return theatre;
        }

    }
}

