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
        private readonly IViewModelMapper<Comment, CommentViewModelMapper> _commentViewModelMapper;
        private readonly IViewModelMapper<Review, ReviewViewModelMapper> _reviewViewModelMapper; 
        private readonly IReviewServices _reviewServices;
        private readonly ILogger _logger;

        public TheatreController(ITheatreService theatreServices, ICommentServices commentServices,
            UserManager<User> userManager, IViewModelMapper<Theatre, TheatreViewModel> theatreViewModelMapper,
            ILogger logger, IViewModelMapper<Comment, CommentViewModelMapper> commentViewModelMapper,
            IReviewServices reviewServices, IViewModelMapper<Review, ReviewViewModelMapper> reviewViewModelMapper)
        {
            _theatreServices = theatreServices ?? throw new ArgumentNullException(nameof(_theatreServices));
            _commentServices = commentServices ?? throw new ArgumentNullException(nameof(_commentServices));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(_userManager));
            _theatreViewModelMapper = theatreViewModelMapper ?? throw new ArgumentNullException(nameof(_theatreViewModelMapper));
            _logger = logger;
            _commentViewModelMapper = commentViewModelMapper ?? throw new ArgumentNullException(nameof(_commentViewModelMapper));
            _reviewServices = reviewServices ?? throw new ArgumentNullException(nameof(_reviewServices));
            _reviewViewModelMapper = reviewViewModelMapper ?? throw new ArgumentNullException(nameof(_reviewViewModelMapper));
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

        //public async Task<IActionResult> Details(Guid id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var theatre = await _theatreServices.GetTheatreAsync(id);
        //    var theatreVm = _theatreViewModelMapper.MapFrom(theatre);

        //    var commentsAll = await _commentServices.GetCommentsAsync(id);
        //    var commentsVM = _commentViewModelMapper.MapFrom(commentsAll);

        //    var reviewAll = await _reviewServices.GetAllReviewsAsync(id);
        //    var reviewVm = _reviewViewModelMapper.MapFrom(reviewAll);

        //    var userId = this._userManager.GetUserId(HttpContext.User);


        //}
    }
}