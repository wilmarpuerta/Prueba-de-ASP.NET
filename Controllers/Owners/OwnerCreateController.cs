
using Microsoft.AspNetCore.Mvc;
using Prueba_de_ASP.NET.Models;
using Prueba_de_ASP.NET.Services.Owners;

namespace Prueba_de_ASP.NET.Controllers.Owners
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnerCreateController : ControllerBase
    {
        private readonly IOwnersRepository _ownerRepository;
        public OwnerCreateController(IOwnersRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        [HttpPost("Create")]
        public ActionResult Create([FromBody] Owner owner)
        {
            try
            {
                _ownerRepository.CreateOwner(owner);
                return Ok();
            }
            catch
            {
                return BadRequest("Error creating owner");
            }
        }
    }
}