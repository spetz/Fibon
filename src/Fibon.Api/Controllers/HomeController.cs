using Microsoft.AspNetCore.Mvc;

namespace Fibon.Api.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Get()
        => Content("Hello from Fibon API!");
    }
}