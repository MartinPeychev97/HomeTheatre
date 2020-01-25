using HomeTheatre.Data;
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
    public class SearchServices : ISearchServices
    {
        private readonly TheatreContext _context;
        private readonly SearchTheatreMapper _searchTheatreMapper;

        public SearchServices(TheatreContext context, SearchTheatreMapper searchTheatreMapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _searchTheatreMapper = searchTheatreMapper ?? throw new ArgumentNullException(nameof(searchTheatreMapper));
        }
        public async Task<ICollection<SearchTheatre>> SearchAsync(string searchCriteria, bool byName, bool ByLocation, bool byRating, double ratingValue)
        {
            if (string.IsNullOrEmpty(searchCriteria))
            {
                var allTheatres = _context.Theatres.Where(b => b.IsDeleted == false).Include(b => b.AverageRating);
                var filteredByRating = await allTheatres.Where(b => byRating ? (b.AverageRating >= ratingValue) : false).ToListAsync();
                var mappedResult = _searchTheatreMapper.MapFrom(filteredByRating);

                return mappedResult;
            }

            var terms = searchCriteria.Split(" ");
            if (byName == false && ByLocation == false && byRating == false)
            {
                var outcome = await _context.Theatres
                    .Where(b => b.IsDeleted == false)
                    .Include(b => b.AverageRating)
                    .Where(b => b.Name.Contains(terms)
                    || b.Location.Contains(terms))
                     .Select(b => _searchTheatreMapper.MapFrom(b))
                    .OrderBy(b => b.Name)
                    .ToListAsync();

                return outcome;
            }

            else
            {
                var allTheatres = _context.Theatres.Where(b => b.IsDeleted == false).Include(b => b.AverageRating);
                var filteredByName = allTheatres.Where(b => byName && b.Name.Contains(terms));
                var filteredByLocation = allTheatres.Where(b => ByLocation && b.Location.Contains(terms));
                var filteredByRating = allTheatres.Where(b => byRating ? (b.AverageRating >= ratingValue) : false);
                var filtered = filteredByName.Union(filteredByLocation).Union(filteredByRating).ToList();
                var mappedResult = filtered.Select(b => _searchTheatreMapper.MapFrom(b)).ToList();

                return mappedResult;
            }
        }
    }
}
