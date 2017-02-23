using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Localization.StarterWeb.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly IStringLocalizer<ValuesController> _valueLocalizer;

        public ValuesController(IStringLocalizer<HomeController> localizer, IStringLocalizer<ValuesController> valueLocalizer)
        {
            _localizer = localizer;
            _valueLocalizer = valueLocalizer;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var message = _localizer["Your application description page."];
            var contact = _localizer["Your contact page."];

            var about = _valueLocalizer["About message"];
            var description = _valueLocalizer["Application description page"];

            ViewData["MessageFromHomeControllerToString"] = _localizer["Your contact page."].ToString();
            ViewData["MessageFromHomeController"] = _localizer["Your contact page."];
            ViewData["MessageFromValuesControllerToString"] = _valueLocalizer["About message"].ToString();
            ViewData["MessageFromValuesController"] = _valueLocalizer["About message"];

            var requestCulture = HttpContext.Features.Get<IRequestCultureFeature>();

            var obj = new
            {
                MessageToString = message.ToString(),
                Msg = message,
                Contact = contact,

                AboutToString = about.ToString(),
                About = about,
                Description = description,

                viewDataMessageFromHomeToString = ViewData["MessageFromHomeControllerToString"],
                viewDataMessageFromHome = ViewData["MessageFromHomeController"],

                viewDataMessageFromValuesToString = ViewData["MessageFromValuesControllerToString"],
                viewDataMessageFromValues = ViewData["MessageFromValuesController"],

                requestCulture = requestCulture.RequestCulture.Culture.Name,
                requestUICulture = requestCulture.RequestCulture.UICulture.Name,

                Culture = System.Globalization.CultureInfo.CurrentCulture.DisplayName,
                CultureUI = System.Globalization.CultureInfo.CurrentUICulture.DisplayName
            };

            return Ok(obj);
        }
    }
}
