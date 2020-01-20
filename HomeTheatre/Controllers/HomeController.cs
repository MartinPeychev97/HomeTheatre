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
using HomeTheatre.Mappers.Contract;
using HomeTheatre.Models.Theatre;
using HomeTheatre.Models.General;

namespace HomeTheatre.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemoryCache _cache;
        private readonly ITheatreService _theatreServices;
        private readonly IViewModelMapper<Theatre, TheatreViewModel> _theatreVmMapper;

        public HomeController(IMemoryCache cache, ITheatreService theatreServices, 
            IViewModelMapper<Theatre, TheatreViewModel> theatreViewModelMapper)
        {
            _cache= cache ?? throw new ArgumentNullException(nameof(cache));
            _theatreServices=theatreServices ?? throw new ArgumentNullException(nameof(theatreServices));
            _theatreVmMapper = theatreViewModelMapper ?? throw new ArgumentNullException(nameof(theatreViewModelMapper));
        }

        public async Task<IActionResult> Index()
        {
            var toptheatresVM = (await CacheTopTheatres())
               .Select(x => _theatreVmMapper.MapFrom(x))
               .ToList();

            var homeViewModel = new HomeViewModel
            {
                TopTheatres = toptheatresVM
            };
            return View(homeViewModel);

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

        [NonAction]
        private async Task<ICollection<Theatre>> CacheTopTheatres()
        {
            var TopTheatres = await _cache.GetOrCreateAsync("Theatre", async (cacheEntry) =>
            {
                cacheEntry.SlidingExpiration = TimeSpan.FromDays(1);
                return await _theatreServices.GetTopTheatresAsync(6);
            });

            return TopTheatres;
        }

        //[NonAction]
        //private async Task<ICollection<Theatre>> CacheSixTheatres()
        //{
        //    var SixTheatres = await _cache.GetOrCreateAsync("Theatre", async (cacheEntry) =>
        //    {
        //        cacheEntry.SlidingExpiration = TimeSpan.FromDays(1);
        //        return await _theatreServices.GetSixTheatresAsync();
        //    });

        //    return SixTheatres;
        //}
    }
}
