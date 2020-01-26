using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HomeTheatre.Data.DbModels;
using HomeTheatre.Mappers;
using HomeTheatre.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeTheatre.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _userService;

        public UserController(IUserServices userService)
        {
            this._userService = userService;
        }

        public async Task<IActionResult> Index(int? currentPage, string search = null)
        {
            var currPage = currentPage ?? 1;

            int totalPages = await _userService.GetPageCount(10);

            IEnumerable<User> emailAllResults = null;

            if (!string.IsNullOrEmpty(search))
            {
                emailAllResults = await _userService.SearchUsers(search, currPage);
            }
            else
            {
                emailAllResults = _userService.GetAll(currPage);
            }

            var userListing = emailAllResults
                .Select(m => UserMapper.MapFromUser(m, _userService));
            var userModel = UserMapper.MapFromUserIndex(userListing, currPage, totalPages);

            userModel.CurrentPage = currPage;
            userModel.TotalPages = totalPages;

            if (totalPages > currPage)
            {
                userModel.NextPage = currPage + 1;
            }

            if (currPage > 1)
            {
                userModel.PreviousPage = currPage - 1;
            }

            return View(userModel);
        }

        public IActionResult Detail(Guid userId)
        {
            var user = _userService.GetUserById(userId);
            var userModel = UserMapper.MapFromUser(user, _userService);

            return View("Detail", userModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public IActionResult BanUser(Guid userId)
        {
            var user = _userService.GetUserById(userId);
            _userService.BanUser(userId);

            var userModel = UserMapper.MapFromUser(user, _userService);

            return View("Detail", userModel);
        }
    }
}