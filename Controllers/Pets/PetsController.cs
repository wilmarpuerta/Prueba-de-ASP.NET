
using Microsoft.AspNetCore.Mvc;
using Prueba_de_ASP.NET.Models;
using Prueba_de_ASP.NET.Services.Pets;

namespace Prueba_de_ASP.NET.Controllers.Pets
{
    [ApiController]
    [Route("api/pets")]
    public class PetsController : ControllerBase
    {
       private readonly IPetsRepository _petsRepository;
       public PetsController(IPetsRepository petsRepository)
       {
           _petsRepository = petsRepository;
       }

       [HttpGet]
       public IEnumerable<Pet> GetOwners()
       {
            try
            {
                return _petsRepository.GetPets();
            }
            catch
            {
                return (IEnumerable<Pet>)BadRequest("Error getting owners");
            }
       }

       [HttpGet("{id}")]
       public Pet GetPetById(int id)
       {
            var Pet = _petsRepository.GetPet(id);
            if(!ModelState.IsValid)
            {
                NotFound("Pet not found");
            }
            
            return Pet;
       }
    }
}