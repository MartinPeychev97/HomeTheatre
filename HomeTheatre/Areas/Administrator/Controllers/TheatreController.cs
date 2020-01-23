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
using HomeTheatre.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HomeTheatre.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Administrator")]
    public class TheatreController : Controller
    {
        private readonly IViewModelMapper<Theatre, TheatreViewModel> _theatreVMmapper;
        private readonly ITheatreService _theatreService;
        private readonly ILogger _logger;
        private readonly IReviewServices _reviewService;
        private readonly ITheatreReviewServices _trServices;

        public TheatreController(IViewModelMapper<Theatre, TheatreViewModel> theatreVMmapper, ITheatreService theatreService, ILogger logger, IReviewServices reviewService,ITheatreReviewServices trServices)
        {
            _theatreVMmapper = theatreVMmapper ?? throw new ArgumentNullException(nameof(theatreVMmapper));
            _theatreService = theatreService ?? throw new ArgumentNullException(nameof(theatreService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _reviewService = reviewService ?? throw new ArgumentNullException(nameof(reviewService));
            _trServices = trServices ?? throw new ArgumentNullException(nameof(trServices));
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReviewToTheatre(TheatreViewModel theatreVM,ReviewViewModel reviewVM)
        {
            if (ModelState.IsValid)
            {
                var theatre = await _theatreService.GetTheatreAsync(theatreVM.Id);
                var review = await _reviewService.GetReviewAsync(reviewVM.Id);
                await _trServices.AddReviewAsync(theatre, review);
                _logger.LogInformation("Review successfully added to Theatre");
                return RedirectToAction("Details", "Theatre", new { id = theatre.Id });
            }
            _logger.LogError("Something went wrong ,Review was not added to theatre");
            return View(theatreVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveReviewFromTheatre(TheatreViewModel theatreVM, ReviewViewModel reviewVM)
        {
            if (ModelState.IsValid)
            {
                var theatre = await _theatreService.GetTheatreAsync(theatreVM.Id);
                var review = await _reviewService.GetReviewAsync(reviewVM.Id);
                await _trServices.RemoveReviewAsync(theatre, review);
                _logger.LogInformation("Review was successfully removed from Theatre");
                return RedirectToAction("Details", "Theatre");
            }
            _logger.LogInformation("Review could not be removed something went wrong");

            return View(theatreVM);

        }
    }
}