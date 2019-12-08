using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HomeTheatre.Data.DbModels;

namespace HomeTheatre.Services.Contracts
{
    public interface ICommentServices
    {
        Task<Comment> CreateCommentAsync(Comment tempComment);
        Task<Comment> DeleteCommentAsync(Guid id);
        Task<Comment> EditCommentAsync(Guid id, string newCommentText);
        Task<ICollection<Comment>> GetCommentsAsync(Guid Id);
    }
}