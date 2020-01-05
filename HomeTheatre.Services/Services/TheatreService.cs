using HomeTheatre.Data;
using HomeTheatre.Data.DbModels;
using HomeTheatre.Data.Utilities;
using HomeTheatre.Services.Contracts;
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
        private readonly TheatreContext context;

        public TheatreService(TheatreContext context)
        {
            this.context = context;
        }

        public async Task<Theatre> GetTheatreAsync(Guid Id)
        {
            var theatre = await context.Theatres
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
            var allTheatres = await context.Theatres
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

            await context.Theatres.AddAsync(theatre);
            await context.SaveChangesAsync();

            return theatre;
        }

        public async Task<Theatre> DeleteTheatreAsync(Guid Id)
        {
            var theatre = await context.Theatres.FirstOrDefaultAsync(b => b.Id == Id);

            if (theatre == null)
            {
                throw new ArgumentNullException("Theatre doesn't exist");
            }
            theatre.IsDeleted = true;
            theatre.DeletedOn = DateTime.UtcNow;
            await context.SaveChangesAsync();

            return theatre;
        }

        public async Task<int> GetPageCountAsync(int theatresPerPage)
        {
            var allTheatres = await context.Theatres
                .Where(b => b.IsDeleted == false)
                .CountAsync();

            var totalPages = (allTheatres - 1) / theatresPerPage + 1;

            return totalPages;
        }

        public async Task<ICollection<Theatre>> GetSixTheatresAsync(int currentPage, string sortOrder)
        {
            try
            {
                IQueryable<Theatre> theatres = context.Theatres
                    .Include(b => b.Reviews)
                    .Where(b => b.IsDeleted == false);

                ICollection<Theatre> sixTheatres;

                switch (sortOrder)
                {
                    case "Name":
                        theatres = theatres.OrderBy(b => b.Name);
                        break;
                    case "name_desc":
                        theatres = theatres.OrderByDescending(b => b.Name);
                        break;
                    case "Review":
                        theatres = theatres.OrderBy(b => b.Reviews.Count());
                        break;
                    case "review_desc":
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

    }
}
