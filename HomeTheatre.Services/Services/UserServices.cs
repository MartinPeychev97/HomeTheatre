using HomeTheatre.Data;
using HomeTheatre.Data.DbModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTheatre.Services.Services
{
    public class UserServices : IUserServices
    {
        private readonly TheatreContext _context;

        public UserServices(TheatreContext context/*, UserManager<User> userManager*/)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public User GetUserById(Guid id)
        {
            return _context.Users.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<User> GetAll(int currentPage)
        {
            IEnumerable<User> userAll = _context.Users
                     .OrderBy(u => u.Id);

            if (currentPage == 1)
            {
                userAll = userAll
                     .Take(10)
                     .ToList();
            }
            else
            {
                userAll = userAll
                    .Skip((currentPage - 1) * 10)
                    .Take(10)
                    .ToList();
            }

            return userAll;
        }

        public User BanUser(Guid userId)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Id == userId);

            user.LockoutEnabled = true;
            var bannedTill = user.LockoutEnd = DateTime.Now.AddDays(30);

            _context.SaveChanges();

            return user;
        }

        public async Task<IEnumerable<User>> SearchUsers(string search, int currentPage)
        {
            IEnumerable<User> searchResult = await _context.Users
                .Where(b => b.Name.Contains(search) ||
                       b.UserName.Contains(search) ||
                       b.Email.Contains(search))
                .OrderBy(b => b.Role)
                .ThenBy(b => b.Id)
                .ToListAsync();

            //if (currentPage == 1)
            //{
            //    searchResult = searchResult
            //        .Take(10)
            //        .ToList();
            //}
            //else
            //{
            //    searchResult = searchResult
            //       .Skip((currentPage - 1) * 10)
            //       .Take(10)
            //       .ToList();
            //}

            return searchResult;
        }

        public async Task<int> GetPageCount(int emailsPerPage)
        {
            var allEmails = await _context.Users.CountAsync();

            var totalPages = (allEmails - 1) / emailsPerPage + 1;

            return totalPages;
        }
    }
}

