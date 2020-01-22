using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HomeTheatre.Areas.Administrator.Controllers
{
    public class ReviewsController : Controller
    {
        public ReviewsController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}