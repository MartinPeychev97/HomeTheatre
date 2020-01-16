using HomeTheatre.Areas.Administrator.Models;
using HomeTheatre.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTheatre.ViewComponents
{
    public class AddReviewToTheatreViewComponent
    {
        private readonly IReviewServices _reviewServices;

        public AddReviewToTheatreViewComponent(IReviewServices reviewServices)
        {
            _reviewServices = reviewServices ?? throw new ArgumentNullException(nameof(reviewServices)); ;
        }

        //public async Task<IViewComponentResult> InvokeAsync(Guid theatreId)
        //{
        //    var model = new AddReviewToTheatreViewModel();
        //    var allReviews = await _reviewServices.GetAllReviewsAsync(theatreId);
        //    model.Id = theatreId;
        //    model.AllReviews = allReviews.Select(a.Author,a.Author).ToList();

        //    return View(model);
        //}
    }
}
