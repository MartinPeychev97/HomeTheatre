using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeTheatre.Data.DbModels;
using HomeTheatre.Mappers;
using HomeTheatre.Mappers.Contract;
using HomeTheatre.Models.Theatre;
using HomeTheatre.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HomeTheatre.Controllers
{
    public class TheatreController : Controller
    {
        private readonly ITheatreService _theatreServices;
        private readonly ICommentServices _commentServices;
        private readonly UserManager<User> _userManager;
        private readonly IViewModelMapper<Theatre, TheatreViewModel> _theatreViewModelMapper;
        private readonly ILogger _logger;

        public TheatreController(ITheatreService theatreServices,ICommentServices commentServices, UserManager<User> userManager,
            IViewModelMapper<Theatre, TheatreViewModel> TheatreViewModelMapper,ILogger logger)
        {
            _theatreServices = theatreServices ?? throw new ArgumentNullException(nameof(_theatreServices));
            _commentServices = commentServices ?? throw new ArgumentNullException(nameof(_commentServices));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(_userManager));
            _theatreViewModelMapper = TheatreViewModelMapper  ?? throw new ArgumentNullException(nameof(_theatreViewModelMapper));
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetSixTheatres(int? currPage, string sortOrder)
        {
            try
            {
                var currentPage = currPage ?? 1;
                var totalPages = await _theatreServices.GetPageCountAsync(5);
                var sixTheatres = await _theatreServices.GetSixTheatresAsync(currentPage, sortOrder);
                var convertedTheatre = _theatreViewModelMapper.MapFrom(sixTheatres);

                var model = new TheatreIndexViewModel()
                {
                    CurrPage = currentPage,
                    TotalPages = totalPages,
                    TheatreModels = convertedTheatre,
                };

                if (totalPages > currentPage)
                {
                    model.NextPage = currentPage + 1;
                }

                if (currentPage > 1)
                {
                    model.PrevPage = currentPage - 1;
                }
                return PartialView("_TheatreIndexTable", model);
            }
            catch (Exception)
            {
                _logger.LogError("Something went wrong");
                return RedirectToAction(nameof(Index));
            }
        }
    }
}