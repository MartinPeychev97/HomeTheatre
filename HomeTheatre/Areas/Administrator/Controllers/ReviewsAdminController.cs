using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HomeTheatre.Areas.Administrator.Controllers
{
    public class ReviewsAdminController : Controller
    {
        public ReviewsAdminController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}