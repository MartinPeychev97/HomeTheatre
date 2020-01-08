using HomeTheatre.Data.DbModels;
using HomeTheatre.Mappers.Contract;
using HomeTheatre.Models.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTheatre.Mappers
{
    public class CommentViewModelMapper : IViewModelMapper<Comment, CommentViewModel>
    {
        public CommentViewModel MapFrom(Comment Entity)
        {
            if (Entity == null)
            {
                throw new Exception("There is no comment given in the parameters");
            }

            return new CommentViewModel
            {
                Id = Entity.Id,
                ReviewId = Entity.ReviewId,
                UserId = Entity.UserId,
                UserName = Entity.UserName,
                CommentText = Entity.CommentText,
                CreatedOn = Entity.CreatedOn,
                ModifiedOn = Entity.ModifiedOn,
                DeletedOn = Entity.DeletedOn,
                IsDeleted = Entity.IsDeleted,
            };
        }

        public ICollection<CommentViewModel> MapFrom(ICollection<Comment> Entities)
        {
            return Entities.Select(MapFrom).ToList();
        }

        public Comment MapFrom(CommentViewModel entityVM)
        {
            if (entityVM == null)
            {
                throw new Exception("No View Model Found");
            }
            return new Comment
            {
                Id = entityVM.Id,
                ReviewId = entityVM.ReviewId,
                UserId = entityVM.UserId,
                UserName= entityVM.UserName,
                CommentText = entityVM.CommentText,
                CreatedOn = entityVM.CreatedOn,
                ModifiedOn = entityVM.ModifiedOn,
                DeletedOn = entityVM.DeletedOn,
                IsDeleted = entityVM.IsDeleted,
            };

        }

        public ICollection<Comment> MapFrom(ICollection<CommentViewModel> entitiesVM)
        {
            return entitiesVM.Select(MapFrom).ToList();
        }
    }
}
