using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeTheatre.Areas.Administrator.Models;
using HomeTheatre.Data.DbModels;
using HomeTheatre.Mappers.Contract;
using HomeTheatre.Models.Review;
using HomeTheatre.Models.Theatre;
using HomeTheatre.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HomeTheatre.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Administrator")]
    public class TheatresAdminController : Controller
    {
        private readonly IViewModelMapper<Theatre, TheatreViewModel> _theatreVMmapper;
        private readonly ITheatreService _theatreService;
        private readonly ILogger _logger;
        private readonly IReviewServices _reviewService;

        public TheatresAdminController(IViewModelMapper<Theatre, TheatreViewModel> theatreVMmapper, ITheatreService theatreService, ILogger logger, IReviewServices reviewService)
        {
            _theatreVMmapper = theatreVMmapper ?? throw new ArgumentNullException(nameof(theatreVMmapper));
            _theatreService = theatreService ?? throw new ArgumentNullException(nameof(theatreService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _reviewService = reviewService ?? throw new ArgumentNullException(nameof(reviewService));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTheatre(TheatreViewModel theatreVM)
        {
            if (ModelState.IsValid)
            {
                var theatreModel = _theatreVMmapper.MapFrom(theatreVM);
                var newlyCreatedTheatre = await _theatreService.CreateTheatreAsync(theatreModel);

                _logger.LogInformation("Theatre Successfully created");
                return RedirectToAction("Details", new { id = newlyCreatedTheatre.Id });
            }
            else
            {
                _logger.LogError("Theatre was not created,something went wrong");
                return RedirectToAction("Index", "Theatre", new { area = "" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTheatre(Guid id, string newName, string newAboutInfo, string newLocation, string newPhone)
        {
            if (ModelState.IsValid)
            {
                var tempTheatre = await _theatreService.UpdateAsync(id, newName, newAboutInfo, newLocation, newPhone);

                _logger.LogInformation("Theatre was successfully updated");
                return RedirectToAction("Details", new { id = tempTheatre.Id });
            }

            _logger.LogError("Theatre update was unsuccessfull, something went wrong");
            return RedirectToAction("Index", "Theatre", new { area = "" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTheatre(Guid id)
        {
            try
            {
                await _theatreService.DeleteTheatreAsync(id);
                _logger.LogInformation("Theatre was successfully deleted");
            }
            catch (Exception)
            {
                _logger.LogError("Theatre deletion was unsuccessfull, something went wrong");
            }
            return RedirectToAction("Index", "Theatre", new { area = "" });
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddReviewToTheatre(TheatreReview theatreReview)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var theatre = await _theatreService.GetTheatreAsync(theatreReview.TheatreId);
        //        var review = await _reviewService.GetReviewAsync(theatreReview.ReviewId);
        //        await _theatreService.AddReviewAsync(theatre, review);
        //        _logger.LogInformation("Review successfully added to Theatre");
        //        return RedirectToAction("Details","Theatre", new { id = theatre.Id });
        //    }

        //}
    }
}