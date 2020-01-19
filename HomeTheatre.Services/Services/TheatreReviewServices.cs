using HomeTheatre.Data;
using HomeTheatre.Data.DbModels;
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

        public async Task<TheatreReview> GetTheatreReviewAsync(Guid theatreReviewId)
        {
            var theatreReview = await _context.TheatreReviews
                .Include(x => x.Review)
                .Include(x=>x.Theatre)
                .Where(x => x.IsDeleted == false)
                .OrderBy(b => b.CreatedOn)
                .FirstOrDefaultAsync(b => b.Id == theatreReviewId);

            if (theatreReview == null)
            {
                throw new ArgumentNullException("The theatreReview you are looking for doesn't exist");
            }

            return theatreReview;
        }

        //public async Task<TheatreReview> GetAllTheatreReviewsAsync(Guid TheatreId)
        //{

        //}

        public async Task<Theatre> AddReviewAsync(Theatre theatreParam, Review reviewParam)
        {
            var theatre = await _context.Theatres.Where(t => t.IsDeleted == false)
                .FirstOrDefaultAsync(t => t.Id == theatreParam.Id);

            if (theatre == null)
            {
                throw new Exception("There was no theatre found");
            }
            var review = await _context.Reviews.Where(c => c.IsDeleted == false)
                .FirstOrDefaultAsync(r => r.Id == reviewParam.Id);
            if (review == null)
            {
                throw new Exception("There was no review found");
            }

            var theatreReview = await _context.TheatreReviews
                    .Where(t => t.TheatreId == theatre.Id && t.ReviewId == review.Id)
                    .FirstOrDefaultAsync();

            if (theatreReview == null)
            {
                theatreReview = new TheatreReview
                {
                    Theatre = theatre,
                    TheatreId = theatre.Id,
                    Review = review,
                    ReviewId = review.Id
                };
                await _context.TheatreReviews.AddAsync(theatreReview);
                theatre.TheatreReviews.Add(theatreReview);
            }
            else
            {
                theatreReview.IsDeleted = false;
            }
            await _context.SaveChangesAsync();
            return theatreParam;
        }

        public async Task<TheatreReview> RemoveReviewAsync(TheatreReview theatreReviewParams)
        {
            var theatreReview = await _context.TheatreReviews.Where(x => x.Id == theatreReviewParams.Id)
                .Where(x => x.IsDeleted == false).FirstOrDefaultAsync();

            if (theatreReview == null)
            {
                throw new ArgumentNullException("There was no theatreReview found");
            }

            theatreReview.IsDeleted = true;
            theatreReview.DeletedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return theatreReviewParams;
        }
       
    }
}

