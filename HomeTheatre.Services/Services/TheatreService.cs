﻿using HomeTheatre.Data;
using HomeTheatre.Data.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTheatre.Services.Services
{
    public class TheatreService
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
                .FirstOrDefaultAsync(b=>b.Id==Id);

            if (theatre == null)
            {
                throw new ArgumentNullException("The theatre you are looking for doesn't exist");
            }

            return theatre;
        }
        public async Task<ICollection<Theatre>> GetAllTheatresAsync()
        {
            var allTheatres = await this.context.Theatres
                .Where(b => b.IsDeleted == false)
                .OrderBy(b => b.Name)
                .ToListAsync();

            if (!allTheatres.Any())
            {
                throw new ArgumentNullException("There are no theatres");
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
                throw new Exception("Theatre doesn't exist");
            }
            theatre.IsDeleted = true;
            theatre.DeletedOn = DateTime.UtcNow;
            await context.SaveChangesAsync();

            return theatre;
        }
       
    }
}
