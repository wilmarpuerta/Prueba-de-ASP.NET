
using Microsoft.AspNetCore.Mvc;

namespace Prueba_de_ASP.NET.Controllers.Owners
{
    [Route("[controller]")]
    public class OwnersController : Controller
    {
        private readonly ILogger<OwnersController> _logger;

        public OwnersController(ILogger<OwnersController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}