
using Microsoft.AspNetCore.Mvc;
using Prueba_de_ASP.NET.Models;
using Prueba_de_ASP.NET.Services.Pets;

namespace Prueba_de_ASP.NET.Controllers.Pets
{
    [Route("api/[controller]")]
    public class PetUpdateController : Controller
    {
        private readonly IPetsRepository _petsRepository;
       public PetUpdateController(IPetsRepository petsRepository)
       {
           _petsRepository = petsRepository;
       }

        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] Pet pet)
        {
            try
            {
                _petsRepository.UpdatePet(id, pet);
                return Ok("Pet updated successfully");
            }
            catch
            {
                return BadRequest("Pet update failed");
            }
        }
        
    }
}