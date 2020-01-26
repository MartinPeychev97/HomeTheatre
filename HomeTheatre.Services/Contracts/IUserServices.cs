using HomeTheatre.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeTheatre.Services.Services
{
    public interface IUserServices
    {
        User BanUser(Guid userId);
        IEnumerable<User> GetAll(int currentPage);
        Task<int> GetPageCount(int emailsPerPage);
        User GetUserById(Guid id);
        Task<IEnumerable<User>> SearchUsers(string search, int currentPage);
    }
}