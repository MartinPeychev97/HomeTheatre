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
    public class CommentServices : ICommentServices
    {
        private readonly TheatreContext _context;

        public CommentServices(TheatreContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<Comment> CreateCommentAsync(Comment tempComment)
        {
            if (tempComment == null)
            {
                throw new ArgumentNullException("The comment is null");
            }
            if (String.IsNullOrEmpty(tempComment.CommentText))
            {
                throw new ArgumentException("This comment is empty");
            }
            var comment = new Comment
            {
                Id = tempComment.Id,
                CommentText = tempComment.CommentText,
                Author = tempComment.Author,
                IsDeleted = tempComment.IsDeleted,
                CreatedOn = tempComment.CreatedOn,
                ModifiedOn = tempComment.ModifiedOn,
                DeletedOn = tempComment.ModifiedOn
            };

            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<ICollection<Comment>> GetCommentsAsync(Guid Id)
        {
            var comments = await _context.Comments
                .Include(c => c.User)
                .Include(c => c.Review)
                .Where(x => x.IsDeleted == false)
                .Where(x => x.Id == Id)
                .ToListAsync();
            return comments;
        }

        public async Task<Comment> DeleteCommentAsync(Guid id)
        {
            var comment = await _context.Comments
                .Include(bc => bc.Review)
                .Include(bc => bc.User)
                .Where(bc => bc.IsDeleted == false)
                .Where(bc => bc.Id == id)
                .FirstOrDefaultAsync();

            if (comment == null)
            {
                throw new ArgumentNullException();
            }
            comment.DeletedOn = DateTime.UtcNow;
            comment.IsDeleted = true;

            _context.Update(comment);
            await _context.SaveChangesAsync();

            return comment;

        }

        public async Task<Comment> EditCommentAsync(Guid id, string newCommentText)
        {
            var comment = await this._context.Comments
                .Where(bc => bc.IsDeleted == false)
                .FirstOrDefaultAsync(bc => bc.Id == id);

            if (comment == null)
            {
                throw new ArgumentNullException();
            }

            comment.ModifiedOn = DateTime.UtcNow;
            comment.CommentText = newCommentText;

            this._context.Update(comment);
            await this._context.SaveChangesAsync();

            return comment;
        }
    }
}
