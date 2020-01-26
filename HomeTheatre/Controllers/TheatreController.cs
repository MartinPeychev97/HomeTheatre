using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeTheatre.Data.DbModels;
using HomeTheatre.Mappers;
using HomeTheatre.Mappers.Contract;
using HomeTheatre.Models.Comment;
using HomeTheatre.Models.General;
using HomeTheatre.Models.Review;
using HomeTheatre.Models.Theatre;
using HomeTheatre.Services.Contracts;
using HomeTheatre.Services.Utility;
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
        private readonly IViewModelMapper<SearchTheatre, TheatreViewModel> _searchTheatreViewModelMapper;
        //private readonly ISearchServices _searchServices;
        private readonly IReviewServices _reviewServices;
        //private readonly ILogger _logger;

        public TheatreController(ITheatreService theatreServices, ICommentServices commentServices,
            UserManager<User> userManager, IViewModelMapper<Theatre, TheatreViewModel> theatreViewModelMapper,
            /*ILogger logger,*/ IViewModelMapper<Comment, CommentViewModel> commentViewModelMapper,
            IReviewServices reviewServices, IViewModelMapper<Review, ReviewViewModel> reviewViewModelMapper,
            IViewModelMapper<SearchTheatre, TheatreViewModel> searchTheatreViewModelMapper
            /*ISearchServices searchServices*/)
        {
            _theatreServices = theatreServices ?? throw new ArgumentNullException(nameof(theatreServices));
            _commentServices = commentServices ?? throw new ArgumentNullException(nameof(commentServices));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(_userManager));
            _theatreViewModelMapper = theatreViewModelMapper ?? throw new ArgumentNullException(nameof(theatreViewModelMapper));
            //_logger = logger ?? throw new ArgumentNullException(nameof(logger)); ;
            _commentViewModelMapper = commentViewModelMapper ?? throw new ArgumentNullException(nameof(commentViewModelMapper));
            _reviewServices = reviewServices ?? throw new ArgumentNullException(nameof(reviewServices));
            _reviewViewModelMapper = reviewViewModelMapper ?? throw new ArgumentNullException(nameof(reviewViewModelMapper));
            _searchTheatreViewModelMapper = searchTheatreViewModelMapper ?? throw new ArgumentNullException(nameof(searchTheatreViewModelMapper));
            //_searchServices = searchServices ?? throw new ArgumentNullException(nameof(searchServices));
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
                //_logger.LogError("Something went wrong");
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

            //var userId = _userManager.GetUserId(HttpContext.User);

            //try
            //{
            //    var theatreAverageRating = await _theatreServices.GetAverageRatingAndNumberOfReviews(theatreId);
            //    theatreVm.AverageRating = theatreAverageRating;
            //   // _logger.LogInformation("Theatre average rating has been assigned ");

            //}
            //catch (Exception)
            //{
            //    theatreVm.AverageRating = 0.6666;
            //}

            //var assignARandNumOfReviews = await _theatreServices.GetAverageRatingAndNumberOfReviews(theatreId);

            if (commentsVM != null)
            {
                theatreVm.CommentsVM = commentsVM;
            }
            else
            {
                theatreVm.CommentsVM = new List<CommentViewModel>();
            }
            if (reviewVm != null)
            {
                theatreVm.ReviewsVM = reviewVm;
            }
            else
            {
                theatreVm.ReviewsVM = new List<ReviewViewModel>();
            }
            return View(theatreVm);

        }

        //[HttpGet]
        //public async Task<IActionResult> Search([FromQuery]SearchTheatreViewModel model)
        //{
        //    try
        //    {
        //        if (string.IsNullOrWhiteSpace(model.SearchName) && model.RatingValue == 0)
        //        {
        //            return View();
        //        }

        //        var result = await _searchServices.SearchAsync(model.SearchName, model.SearchByName, model.SearchByLocation, model.SearchByRating, model.RatingValue);
        //        //model.SearchResults = result.Select(b => _searchTheatreViewModelMapper.MapFrom(b)).ToList();

        //        return View(model);
        //    }
        //    catch (Exception)
        //    {
        //        //_logger.LogInformation("Search failed,please try again");
        //        return View();
        //    }
        //}
    }
}