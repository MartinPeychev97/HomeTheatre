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
        private readonly TheatreContext context;

        public CommentServices(TheatreContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
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

            await context.Comments.AddAsync(comment);
            await context.SaveChangesAsync();
            return comment;
        }

        public async Task<ICollection<Comment>> GetCommentsAsync(Guid Id)
        {
            var comments = await context.Comments
                .Include(c => c.User)
                .Include(c => c.Review)
                .Where(x => x.IsDeleted == false)
                .Where(x => x.Id == Id)
                .ToListAsync();
            return comments;
        }

        public async Task<Comment> DeleteCommentAsync(Guid id)
        {
            var comment = await context.Comments
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

            context.Update(comment);
            await context.SaveChangesAsync();

            return comment;

        }

        public async Task<Comment> EditCommentAsync(Guid id, string newCommentText)
        {
            var comment = await this.context.Comments
                .Where(bc => bc.IsDeleted == false)
                .FirstOrDefaultAsync(bc => bc.Id == id);

            if (comment == null)
            {
                throw new ArgumentNullException();
            }

            comment.ModifiedOn = DateTime.UtcNow;
            comment.CommentText = newCommentText;

            this.context.Update(comment);
            await this.context.SaveChangesAsync();

            return comment;
        }
    }
}
