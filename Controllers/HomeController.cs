using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Localization.StarterWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> _localizer;

        public HomeController(IStringLocalizer<HomeController> localizer)
        {
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = _localizer["Your application description page."];

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = _localizer["Your contact page."];

            return View();
        }

        [HttpGet]
        public IActionResult GetHash()
        {
            int ticks = (int)(DateTime.UtcNow.Ticks - new DateTime(2016, 01, 01).Ticks);
            int nano = ticks > 0 ? ticks : ticks * (-1);


            var message = _localizer["Your application description page."];
            var contact = _localizer["Your contact page."];

            var requestCulture = HttpContext.Features.Get<IRequestCultureFeature>();


            var obj = new
            {
                Key = nano.ToString(),
                Msg = message,
                Message = message.ToString(),
                Contact = contact,
                requestCulture = requestCulture.RequestCulture.Culture.Name,
                requestUICulture = requestCulture.RequestCulture.UICulture.Name,
                Culture = System.Globalization.CultureInfo.CurrentCulture.DisplayName,
                CultureUI = System.Globalization.CultureInfo.CurrentUICulture.DisplayName
            };

            return Ok(obj);
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
