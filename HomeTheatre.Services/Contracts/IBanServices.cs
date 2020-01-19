using HomeTheatre.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeTheatre.Services.Contracts
{
    public interface IBanServices
    {
        //Task CheckForExpiredBansAsync();
        Task CreateBanAsync(Guid id, string reason, int duration);
        Task<ICollection<User>> GetAllBannedUsersAsync(string param);
        Task<User> GetBannedUserAsync(Guid id);
        Task RemoveBanAsync(Guid id);
    }
}