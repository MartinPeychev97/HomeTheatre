using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeTheatre.Areas.Administrator.Models;
using HomeTheatre.Data.DbModels;
using HomeTheatre.Mappers.Contract;
using HomeTheatre.Models.User;
using HomeTheatre.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HomeTheatre.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Administrator")]
    public class UsersAdminController : Controller
    {
        private readonly IBanServices _banService;
        private readonly IViewModelMapper<User, UserViewModel> _userMapper;
        private readonly ILogger _logger;

        public UsersAdminController(IBanServices banService, IViewModelMapper<User, UserViewModel> userMapper,ILogger logger)
        {
            _banService = banService ?? throw new ArgumentNullException(nameof(banService));
            _userMapper = userMapper ?? throw new ArgumentNullException(nameof(userMapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IActionResult> Index()
        {
            var activeUsers = await _banService.GetAllBannedUsersAsync("active");
            var bannedUsers = await _banService.GetAllBannedUsersAsync("banned");
            var activeUsersVM = _userMapper.MapFrom(activeUsers);
            var bannedUsersVM = _userMapper.MapFrom(bannedUsers);

            var allUsersVM = new UserCollectionsViewModel
            {
                ActiveUsers = activeUsersVM,
                BannedUsers = bannedUsersVM
            };

            return View(allUsersVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBan(Guid id, BanViewModel BanVM)
        {
            if (ModelState.IsValid)
            {
                await _banService.CreateBanAsync(id, BanVM.BanReason, BanVM.DurationInDays);
                _logger.LogInformation("User has been succesfully banned");
                return RedirectToAction("Index", "Users");
            }
            ModelState.AddModelError(String.Empty, "Please fill in the form!");
            _logger.LogInformation("User could not be banned");
            return View(BanVM);
        }

        [HttpGet]
        public async Task<IActionResult> GetUnban(Guid id)
        {

            var user = await _banService.GetBannedUserAsync(id);
            var userVM = _userMapper.MapFrom(user);

            return View(userVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UnbanConfirmed(Guid id)
        {

            await _banService.RemoveBanAsync(id);
            _logger.LogInformation("User has been successfully unbanned");
            return RedirectToAction("Index", "Users");
        }
    }
}