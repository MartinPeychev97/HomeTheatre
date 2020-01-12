using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HomeTheatre.Areas.Member.Controllers
{
    public class RatingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}