﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeTheatre.Data.DbModels;
using HomeTheatre.Mappers.Contract;
using HomeTheatre.Models.Review;
using HomeTheatre.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HomeTheatre.Controllers
{
    [Authorize(Roles = "Administrator, Member")]
    public class ReviewsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IReviewServices _reviewServices;
        private readonly IViewModelMapper<Review, ReviewViewModel> _reviewMapper;
        //private readonly ILogger _logger;

        public ReviewsController(UserManager<User> userManager,
            IReviewServices commentServices,
            IViewModelMapper<Review, ReviewViewModel> commentMapper/*, ILogger logger*/)
        {
            _userManager = userManager;
            _reviewServices = commentServices;
            _reviewMapper = commentMapper;
            //_logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index(ReviewViewModel viewModel)
        {
            if (viewModel.TheatreId == null)
            {
                return NotFound();
            }

            var reviews = await _reviewServices.GetAllReviewsAsync(viewModel.TheatreId);
            var reviewsVm = _reviewMapper.MapFrom(reviews);

            return View(reviewsVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReview(ReviewViewModel viewModel)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);

                viewModel.UserId = user.Id;
                viewModel.Author = user.UserName;
                var review = _reviewMapper.MapFrom(viewModel);

                var newComment = await _reviewServices.CreateReviewAsync(review);

                var newReviewVm = _reviewMapper.MapFrom(newComment);

                //_logger.LogInformation("Review has been posted successfully");

                //ADDED
                return RedirectToAction("Index", "Home", viewModel);

            }
            catch (Exception)
            {
                //_logger.LogCritical("Review must be between 2 and 500 characters");
                //return RedirectToAction("Theatre", viewModel);
            }

            return RedirectToAction("Index", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditReview(Guid reviewId, string newBody)
        {
            if (reviewId == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _reviewServices.EditReviewAsync(reviewId, newBody);
                }
                catch (Exception)
                {
                    throw new Exception("Something went wrong");
                }
                // _logger.LogInformation("Review was edited successfully");
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteReview(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await _reviewServices.DeleteReviewAsync(id);
            //_logger.LogInformation("Review has been succesfully deleted");

            return RedirectToAction("Index", "Home");
        }
    }
}