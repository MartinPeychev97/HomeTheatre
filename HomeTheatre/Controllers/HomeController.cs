using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HomeTheatre.Models;
using Microsoft.Extensions.Caching.Memory;
using HomeTheatre.Services.Contracts;
using HomeTheatre.Data.DbModels;

namespace HomeTheatre.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemoryCache _cache;
        private readonly ITheatreService _theatreServices;
        public HomeController(IMemoryCache cache, ITheatreService theatreServices)
        {
            _cache= cache ?? throw new ArgumentNullException(nameof(cache));
            _theatreServices=theatreServices ?? throw new ArgumentNullException(nameof(theatreServices));

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult PageNotFound()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //[NonAction]
        //private async Task<ICollection<Theatre>> CacheTheatres()
        //{
        //    var topBarsDtos = await _cache.GetOrCreateAsync<ICollection<Theatre>>("Theatre", async (cacheEntry) =>
        //    {
        //        cacheEntry.SlidingExpiration = TimeSpan.FromDays(1);
        //        return await _theatreServices.GetSixTheatresAsync();
        //    });

        //    return topBarsDtos;
        //}
    }
}
