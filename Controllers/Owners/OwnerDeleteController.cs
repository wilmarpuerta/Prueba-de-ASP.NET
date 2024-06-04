
using Microsoft.AspNetCore.Mvc;

namespace Prueba_de_ASP.NET.Controllers.Owners
{
    [Route("[controller]")]
    public class OwnerDeleteController : Controller
    {
        private readonly ILogger<OwnerDeleteController> _logger;

        public OwnerDeleteController(ILogger<OwnerDeleteController> logger)
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