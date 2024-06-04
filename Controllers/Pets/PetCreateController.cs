
using Microsoft.AspNetCore.Mvc;
using Prueba_de_ASP.NET.Models;
using Prueba_de_ASP.NET.Services.Pets;

namespace Prueba_de_ASP.NET.Controllers.Pets
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetCreateController : ControllerBase
    {
       private readonly IPetsRepository _petsRepository;
       public PetCreateController(IPetsRepository petsRepository)
       {
           _petsRepository = petsRepository;
       }

        [HttpPost("Create")]
        public ActionResult Create([FromBody] Pet pet)
        {
            try
            {
                _petsRepository.CreatePet(pet);
                return Ok();
            }
            catch
            {
                return BadRequest("Error creating pet");
            }
        }
    }
}