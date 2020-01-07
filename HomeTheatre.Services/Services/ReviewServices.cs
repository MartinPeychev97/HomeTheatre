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
        private readonly TheatreContext context;

        public ReviewServices(TheatreContext context)
        {
            this.context = context;
        }

        public async Task<Review> CreateReviewAsync(Review tempReview)
        {
            if (tempReview == null)
            {
                throw new ArgumentNullException("The review is null");
            }
            if (String.IsNullOrEmpty(tempReview.ReviewText))
            {
                throw new ArgumentException("This review is empty");
            }
            var review = new Review
            {
                Id = tempReview.Id,
                ReviewText = tempReview.ReviewText,
                Author = tempReview.Author,
                IsDeleted = tempReview.IsDeleted,
                DateReviewed = tempReview.DateReviewed,
                CreatedOn = tempReview.CreatedOn,
                ModifiedOn = tempReview.ModifiedOn,
                DeletedOn = tempReview.ModifiedOn
            };

            await context.Reviews.AddAsync(review);
            await context.SaveChangesAsync();
            return review;
        }
        public async Task<Review> DeleteReviewAsync(Guid id)
        {
            var review = await context.Reviews
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

            context.Update(review);
            await context.SaveChangesAsync();

            return review;
        }



        public async Task<ICollection<Review>> GetAllReviewsAsync(Guid theatreId)
        {
            var reviews = await context.Reviews
                .Include(x => x.Theatre)
                .Include(x => x.User)
                .Where(x => x.IsDeleted == false)
                .Where(x => x.TheatreId == theatreId)
                .ToListAsync();

            if (!reviews.Any())
            {
                throw new ArgumentNullException("There are no reviews");
            }
            return reviews;
        }

        public async Task<Review> GetReviewAsync(Guid id)
        {
            var review = await context.Reviews
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
            var review = await context.Reviews
                .Where(bc => bc.IsDeleted == false)
                .FirstOrDefaultAsync(bc => bc.Id == id);

            if (review == null)
            {
                throw new ArgumentNullException();
            }

            review.ModifiedOn = DateTime.UtcNow;
            review.ReviewText = newReviewText;

            context.Update(review);
            await context.SaveChangesAsync();

            return review;
        }
    }
}
