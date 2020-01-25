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
    public class BanServices : IBanServices
    {
        private readonly TheatreContext _context;

        public BanServices(TheatreContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ICollection<User>> GetAllBannedUsersAsync(string param)
        {
            var users = new List<User>();
            if (param == "active")
            {
                users = await _context.Users
                    .Where(u => u.IsBanned == false
                    && u.UserName != "AdminFirst")
                    .ToListAsync();
            }
            else if (param == "banned")
            {
                users = await _context.Users
                    .Include(b => b.Bans)
                    .Where(u => u.IsBanned == true)
                    .ToListAsync();
            }
            return users;
        }

        public async Task<User> GetBannedUserAsync(Guid id)
        {
            var user = await _context.Users
                .Include(u => u.Bans)
                .Where(u => u.IsBanned == true)
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();

            return user;
        }

        public async Task CreateBanAsync(Guid id, string reason, int duration)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                throw new ArgumentNullException("There was no user found");
            }
            try
            {
                var ban = new Ban()
                {
                    ReasonBanned = reason,
                    User = user,
                    ExpiresOn = DateTime.UtcNow.AddDays(duration)
                };

                user.Bans.Add(ban);
                user.IsBanned = true;
                user.LockoutEnabled = true;
                user.LockoutEnd = ban.ExpiresOn;
                await _context.Bans.AddAsync(ban);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception("The Ban was not completed,something went wrong");
            }
        }

        public async Task RemoveBanAsync(Guid id)
        {

            var ban = await _context.Bans
            .Include(u => u.User)
            .Where(b => b.User.Id == id
            && b.HasExpired == false)
            .FirstOrDefaultAsync();

            if (ban == null)
            {
                throw new ArgumentNullException("There was no ban found");
            }

            ban.ExpiresOn = DateTime.UtcNow;
            ban.HasExpired = true;
            ban.User.IsBanned = false;
            ban.User.LockoutEnd = DateTime.UtcNow;
            ban.User.LockoutEnabled = false;

            await _context.SaveChangesAsync();
        }
    }
}
