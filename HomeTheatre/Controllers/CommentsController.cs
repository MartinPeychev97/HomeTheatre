using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeTheatre.Data.DbModels;
using HomeTheatre.Mappers.Contract;
using HomeTheatre.Models.Comment;
using HomeTheatre.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HomeTheatre.Controllers
{
    [Authorize(Roles = "Member")]
    public class CommentsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ICommentServices _commentServices;
        private readonly IViewModelMapper<Comment, CommentViewModel> _commentMapper;
        private readonly ILogger _logger;

        public CommentsController(UserManager<User> userManager, ICommentServices commentServices, IViewModelMapper<Comment, CommentViewModel> commentMapper, ILogger logger)
        {
            _userManager = userManager;
            _commentServices = commentServices;
            _commentMapper = commentMapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index(Guid reviewId)
        {
            if (reviewId == null)
            {
                return NotFound();
            }
            var comments = await _commentServices.GetCommentsAsync(reviewId);
            var commentsVm = _commentMapper.MapFrom(comments);

            return View(commentsVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateComment([FromBody]CommentViewModel viewModel)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                var userName = user.UserName;

                viewModel.UserId = user.Id;
                viewModel.Author = userName;
                var comment = _commentMapper.MapFrom(viewModel);

                var newComment = await _commentServices.CreateCommentAsync(comment);

                var newCommentVm = _commentMapper.MapFrom(newComment);

                _logger.LogInformation("Comment has been posted successfully");

                return PartialView("_AddCommentPartial", newCommentVm);
            }
            catch (Exception)
            {
                _logger.LogCritical("Comment must be between 2 and 500 characters");
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditComment(Guid commentId, string newBody)
        {
            if (commentId == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _commentServices.EditCommentAsync(commentId, newBody);
                }
                catch (Exception)
                {
                    throw new Exception("Something went wrong");
                }
                _logger.LogInformation("Comment was edited successfully");
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteComment(Guid id,Guid reviewId)
        {
            if ( id == null)
            {
                return NotFound();
            }
            await _commentServices.DeleteCommentAsync(id,reviewId);
            _logger.LogInformation("Comment has been succesfully deleted");

            return RedirectToAction("Index", "Home");
        }
    }

}