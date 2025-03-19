using Microsoft.AspNetCore.Mvc;
using SMSystem.Application.Extensions.Localization;
using System.Globalization;

namespace SMSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILocalizationService _localizationService;

        public HomeController(ILocalizationService localizationService)
        {
            _localizationService = localizationService;
        }

        [HttpGet("welcome")]
        public IActionResult Welcome()
        {
            var message = _localizationService.GetLocalizedString("Welcome");
            return Ok(message);
        }

        [HttpGet("welcome/{culture}")]
        public IActionResult WelcomeWithCulture(string culture)
        {
            try
            {
                var cultureInfo = new CultureInfo(culture);
                var message = _localizationService.GetLocalizedString("Welcome", cultureInfo);
                return Ok(message);
            }
            catch
            {
                return BadRequest("Invalid culture");
            }
        }
    }
}