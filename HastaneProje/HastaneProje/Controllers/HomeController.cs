using HastaneProje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Localization;
using System.Diagnostics;
using System.Globalization;
using Microsoft.AspNetCore.WebUtilities;

namespace HastaneProje.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _localizer;
        public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize]

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            var supportedCultures = new[] { "en", "tr", "fr"};

            // Ensure the requested culture is supported
            if (supportedCultures.Contains(culture))
            {
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1),
                    IsEssential = true,
                    SameSite = SameSiteMode.Strict
                };

                // Set culture in the response cookie
                Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    cookieOptions
                );

                // Set the culture for the current thread
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
                System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            }

            Console.WriteLine($"Selected culture: {culture}, returnUrl: {returnUrl}");

            // Redirect to the original URL
            return LocalRedirect(returnUrl);
        }
    }
}
