using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeTheatre.Data.DbModels;
using HomeTheatre.Mappers.Contract;
using HomeTheatre.Models.Theatre;
using HomeTheatre.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HomeTheatre.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Administrator")]
    public class TheatresAllController : Controller
    {
        private readonly IViewModelMapper<Theatre, TheatreViewModel> _theatreVMmapper;
        private readonly ITheatreService _theatreService;
        private readonly ILogger _logger;

        public TheatresAllController(IViewModelMapper<Theatre, TheatreViewModel> theatreVMmapper,ITheatreService theatreService,ILogger logger)
        {
            _theatreVMmapper = theatreVMmapper ?? throw new ArgumentNullException(nameof(theatreVMmapper));
            _theatreService = theatreService ?? throw new ArgumentNullException(nameof(theatreService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}