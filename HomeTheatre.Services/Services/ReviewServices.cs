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
    public class ReviewServices : IReviewServices
    {
        private readonly TheatreContext _context;

        public ReviewServices(TheatreContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Review> CreateReviewAsync(Review tempReview)
        {
            Guid reviewId = Guid.NewGuid();

            if (tempReview == null)
            {
                throw new ArgumentNullException("The review is null");
            }
            if (String.IsNullOrEmpty(tempReview.ReviewText))
            {
                throw new ArgumentException("This review is empty");
            }
            var getReviews = _context.Reviews
                .Include(x => x.Theatre);

            var isTrue = false;

            foreach (var item in getReviews)
            {
                var checkUser = item.Author == tempReview.Author;
                var checkTheaher = item.TheatreId == tempReview.TheatreId;

                if (checkTheaher != false && checkUser != false)
                {
                    isTrue = true;
                    break;
                }
            }

            if (isTrue == false)
            {
                var review = new Review
                {
                    Id = reviewId,
                    ReviewText = tempReview.ReviewText,
                    Author = tempReview.Author,
                    Rating = tempReview.Rating,
                    IsDeleted = tempReview.IsDeleted,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = tempReview.ModifiedOn,
                    DeletedOn = tempReview.ModifiedOn,
                    TheatreId = tempReview.TheatreId
                };

                await _context.Reviews.AddAsync(review);
                await _context.SaveChangesAsync();

                return review;
            }

            throw new Exception("You can not write more than one review for theatre.");
        }

        public async Task<Review> DeleteReviewAsync(Guid id)
        {
            var review = await _context.Reviews
                .Include(bc => bc.Theatre)
                .Include(bc => bc.User)
                .Where(bc => bc.IsDeleted == false)
                .Where(bc => bc.Id == id)
                .FirstOrDefaultAsync();

            if (review == null)
            {
                throw new ArgumentNullException();
            }
            review.DeletedOn = DateTime.UtcNow;
            review.IsDeleted = true;

            _context.Update(review);
            await _context.SaveChangesAsync();

            return review;
        }

        public async Task<ICollection<Review>> GetAllReviewsAsync(Guid theatreId)
        {
            var reviews = await _context.Reviews
                .Include(x => x.Theatre)
                .Include(x => x.User)
                .Where(x => x.IsDeleted == false)
                .Where(x => x.TheatreId == theatreId)
                .ToListAsync();

            //if (!reviews.Any())
            //{
            //    throw new ArgumentNullException("There are no reviews");
            //}

            return reviews;
        }

        public async Task<Review> GetReviewAsync(Guid id)
        {
            var review = await _context.Reviews
                .Where(i => i.IsDeleted == false)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (review == null)
            {
                return null;
            }

            return review;
        }

        public async Task<Review> EditReviewAsync(Guid id, string newReviewText)
        {
            var review = await _context.Reviews
                .Where(bc => bc.IsDeleted == false)
                .FirstOrDefaultAsync(bc => bc.Id == id);

            if (review == null)
            {
                throw new ArgumentNullException();
            }

            review.ModifiedOn = DateTime.UtcNow;
            review.ReviewText = newReviewText;

            _context.Update(review);
            await _context.SaveChangesAsync();

            return review;
        }
    }
}
