
using Microsoft.AspNetCore.Mvc;

namespace Prueba_de_ASP.NET.Controllers.Owners
{
    [Route("[controller]")]
    public class OwnerCreate : Controller
    {
        private readonly ILogger<OwnerCreate> _logger;

        public OwnerCreate(ILogger<OwnerCreate> logger)
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