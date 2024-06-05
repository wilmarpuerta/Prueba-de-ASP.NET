
using Microsoft.AspNetCore.Mvc;
using Prueba_de_ASP.NET.Models;
using Prueba_de_ASP.NET.Services.Owners;

namespace Prueba_de_ASP.NET.Controllers.Owners
{
    [Route("api/owners")]
    public class OwnerUpdateController : Controller
    {
        private readonly IOwnersRepository _ownersRepository;
        public OwnerUpdateController(IOwnersRepository ownersRepository)
        {
            _ownersRepository = ownersRepository;
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Owner owner)
        {
            try
            {
                _ownersRepository.UpdateOwner(id, owner);
                return Ok("Owner updated successfully");
            }
            catch
            {
                return BadRequest("Owner update failed");
            }
        }
        
    }
}