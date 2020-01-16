using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeTheatre.Data.DbModels;
using HomeTheatre.Mappers.Contract;
using HomeTheatre.Models.Theatre;
using HomeTheatre.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HomeTheatre.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class RatingsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ITheatreService _theatreServices;
        private readonly IViewModelMapper<Rating, TheatreRatingViewModel> _modelMapper;

        public RatingsController(UserManager<User> userManager, ITheatreService theatreServices, IViewModelMapper<Rating, TheatreRatingViewModel> modelMapper)
        {
            _theatreServices = theatreServices ?? throw new ArgumentNullException(nameof(theatreServices));
            _modelMapper = modelMapper ?? throw new ArgumentNullException(nameof(modelMapper));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRating(TheatreRatingViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var userName = user.UserName;

                viewModel.UserId = user.Id;
                viewModel.UserName = userName;
                var newRating = _modelMapper.MapFrom(viewModel);

                await _theatreServices.GetAverageRating(viewModel.TheatreId);

                return RedirectToAction("Details", "Theatres", new { id = viewModel.TheatreId });
            }
            return View(viewModel);
        }
    }
}