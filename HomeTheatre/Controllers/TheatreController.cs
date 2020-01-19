using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeTheatre.Data.DbModels;
using HomeTheatre.Mappers;
using HomeTheatre.Mappers.Contract;
using HomeTheatre.Models.Comment;
using HomeTheatre.Models.Review;
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
        private readonly IViewModelMapper<Comment, CommentViewModel> _commentViewModelMapper;
        private readonly IViewModelMapper<Review, ReviewViewModel> _reviewViewModelMapper;
        private readonly IReviewServices _reviewServices;
        private readonly ILogger _logger;

        public TheatreController(ITheatreService theatreServices, ICommentServices commentServices,
            UserManager<User> userManager, IViewModelMapper<Theatre, TheatreViewModel> theatreViewModelMapper,
            ILogger logger, IViewModelMapper<Comment, CommentViewModel> commentViewModelMapper,
            IReviewServices reviewServices, IViewModelMapper<Review, ReviewViewModel> reviewViewModelMapper)
        {
            _theatreServices = theatreServices ?? throw new ArgumentNullException(nameof(theatreServices));
            _commentServices = commentServices ?? throw new ArgumentNullException(nameof(commentServices));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(_userManager));
            _theatreViewModelMapper = theatreViewModelMapper ?? throw new ArgumentNullException(nameof(theatreViewModelMapper));
            _logger = logger;
            _commentViewModelMapper = commentViewModelMapper ?? throw new ArgumentNullException(nameof(commentViewModelMapper));
            _reviewServices = reviewServices ?? throw new ArgumentNullException(nameof(reviewServices));
            _reviewViewModelMapper = reviewViewModelMapper ?? throw new ArgumentNullException(nameof(reviewViewModelMapper));
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

        public async Task<IActionResult> Details(Guid theatreId)
        {
            if (theatreId == null)
            {
                return NotFound();
            }
            var theatre = await _theatreServices.GetTheatreAsync(theatreId);
            var theatreVm = _theatreViewModelMapper.MapFrom(theatre);

            var commentsAll = await _commentServices.GetCommentsAsync(theatreId);
            var commentsVM = _commentViewModelMapper.MapFrom(commentsAll);

            var reviewAll = await _reviewServices.GetAllReviewsAsync(theatreId);
            var reviewVm = _reviewViewModelMapper.MapFrom(reviewAll);

            var userId = _userManager.GetUserId(HttpContext.User);

            try
            {
                var theatreAverageRating = await _theatreServices.GetAverageRating(theatreId);
                theatreVm.AverageRating = theatreAverageRating;
                _logger.LogInformation("Theatre average rating has been assigned ");

            }
            catch (Exception)
            {
                theatreVm.AverageRating = null;
            }

            if (commentsVM !=null)
            {
                theatreVm.CommentsVM = commentsVM;
            }
            else
            {
                theatreVm.CommentsVM = new List<CommentViewModel>();
            }
            if (reviewVm !=null)
            {
                theatreVm.ReviewsVM = reviewVm;
            }
            else
            {
                theatreVm.ReviewsVM = new List<ReviewViewModel>();
            }
            return View(theatreVm);

        }

    }
}