using HomeTheatre.Data;
using HomeTheatre.Data.DbModels;
using HomeTheatre.Data.Utilities;
using HomeTheatre.Services.Contracts;
using HomeTheatre.Services.Utility;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTheatre.Services.Services
{
    public class TheatreService : ITheatreService
    {
        private readonly TheatreContext _context;

        public TheatreService(TheatreContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Theatre> GetTheatreAsync(Guid Id)
        {
            var theatre = await _context.Theatres
                .Include(x => x.Reviews)
                .Where(x => x.IsDeleted == false)
                .OrderBy(b => b.Name)
                .FirstOrDefaultAsync(b => b.Id == Id);

            if (theatre == null)
            {
                throw new Exception("The theatre you are looking for doesn't exist");
            }

            return theatre;
        }
        public async Task<ICollection<Theatre>> GetAllTheatresAsync()
        {
            var allTheatres = await _context.Theatres
                .Where(b => b.IsDeleted == false)
                .OrderBy(b => b.Name)
                .ToListAsync();

            if (!allTheatres.Any())
            {
                throw new Exception("There are no theatres");
            }
            return allTheatres;
        }

        public async Task<Theatre> CreateTheatreAsync(Theatre tempTheatre)
        {
            if (tempTheatre == null)
            {
                throw new ArgumentNullException();
            }
            var theatre = new Theatre
            {
                Name = tempTheatre.Name,
                AboutInfo = tempTheatre.AboutInfo,
                Location = tempTheatre.Location,
                Phone = tempTheatre.Phone
            };

            await _context.Theatres.AddAsync(theatre);
            await _context.SaveChangesAsync();

            return theatre;
        }

        public async Task<Theatre> DeleteTheatreAsync(Guid Id)
        {
            var theatre = await _context.Theatres.FirstOrDefaultAsync(b => b.Id == Id);

            if (theatre == null)
            {
                throw new ArgumentNullException("Theatre doesn't exist");
            }
            theatre.IsDeleted = true;
            theatre.DeletedOn = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return theatre;
        }

        public async Task<int> GetPageCountAsync(int theatresPerPage)
        {
            var allTheatres = await _context.Theatres
                .Where(b => b.IsDeleted == false)
                .CountAsync();

            var totalPages = (allTheatres - 1) / theatresPerPage + 1;

            return totalPages;
        }

        public async Task<ICollection<Theatre>> GetSixTheatresAsync(int currentPage, string sortOrder)
        {
            try
            {
                IQueryable<Theatre> theatres = _context.Theatres
                    .Include(b => b.Reviews)
                    .Where(b => b.IsDeleted == false);

                ICollection<Theatre> sixTheatres;

                switch (sortOrder)
                {
                    case "Name":
                        theatres = theatres.OrderBy(b => b.Name);
                        break;
                    case "NameByDescending":
                        theatres = theatres.OrderByDescending(b => b.Name);
                        break;
                    case "Review":
                        theatres = theatres.OrderBy(b => b.Reviews.Count());
                        break;
                    case "ReviewByDescending":
                        theatres = theatres.OrderByDescending(b => b.Reviews.Count());
                        break;
                    default:
                        theatres = theatres.OrderBy(b => b.Name);
                        break;
                }

                if (currentPage == 1)
                {
                    sixTheatres = await theatres
                        .Take(6)
                        .ToListAsync();
                }
                else
                {
                    sixTheatres = await theatres
                        .Skip((currentPage - 1) * 6)
                        .Take(6)
                        .ToListAsync();
                }

                return sixTheatres;
            }
            catch (Exception)
            {
                throw new Exception("Theatre was not found");
            }
        }


        public async Task<Theatre> UpdateAsync(Guid id, string newName, string newAboutInfo, string newLocattion, string newPhone)
        {
            var theatre = await this._context.Theatres
                .Where(b => b.IsDeleted == false)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (theatre == null)
            {
                throw new Exception("No theatre found");
            }

            try
            {
                theatre.Name = newName;
                theatre.AboutInfo = newAboutInfo;
                theatre.Location = newLocattion;
                theatre.Phone = newPhone;

                this._context.Update(theatre);
                await this._context.SaveChangesAsync();

                return theatre;
            }
            catch (Exception)
            {
                throw new Exception("Something Went wrong");
            }
        }
        public async Task<double> GetAverageRating(Guid theatreId)
        {
            var theatre = await _context.Theatres
                .Include(t => t.Reviews)
                .Where(b => b.IsDeleted == false)
                .FirstOrDefaultAsync(b => b.Id == theatreId);

            double RatingSum = 0;
            foreach (var review in theatre.Reviews)
            {
                RatingSum += review.Rating;
            }
            double averageRating = RatingSum / theatre.Reviews.Count;
            return averageRating;
        }

        public async Task<ICollection<Theatre>> GetTopTheatresAsync(int num)
        {
            var allTheatres = _context.Theatres;

            foreach (var theatre in allTheatres)
            {
                await GetAverageRating(theatre.Id);
            }

            var topTheatres = await allTheatres
                 .Include(b => b.Reviews)
                 .Where(b => b.IsDeleted == false)
                 .OrderByDescending(b => b.AverageRating)
                 .Take(num)
                 .ToListAsync();

            if (!topTheatres.Any())
            {
                throw new Exception("There aren't any theatres found");
            }

            return topTheatres;
        }

    }
}
