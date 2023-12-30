using HastaneProje.Models;
using System;
using System.Data;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace HastaneProje.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<Account> _userManager;

        public HomeController(IStringLocalizer<HomeController> localizer, ILogger<HomeController> logger, UserManager<Account> userManager)
        {
            _localizer = localizer;
            _logger = logger;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Account acc)
        {
            if (ModelState.IsValid)
                ViewBag.Message = _localizer["Kabul"];

            return View();
        }
    }
}
