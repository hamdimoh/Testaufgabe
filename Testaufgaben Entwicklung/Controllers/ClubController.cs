using System;
using Microsoft.AspNetCore.Mvc;
using Testaufgaben_Entwicklung.Services;

namespace Testaufgaben_Entwicklung.Controllers
{
	public class ClubController : Controller
    {
        private readonly ClubService _clubService;

        public ClubController(ClubService clubService)
        {
            _clubService = clubService;
        }

        public async Task<IActionResult> Index()
        {
            var clubs = await _clubService.GetClubsAsync();
            return View(clubs);
        }
        public async Task<IActionResult> Filtered(int yearEstablished = 0)
        {
            var clubs = await _clubService.GetClubsByLeagueAsync(yearEstablished);
            return View(clubs);
        }
    }
}

