
using Microsoft.AspNetCore.Mvc;
using Prueba_de_ASP.NET.Models;
using Prueba_de_ASP.NET.Services.Owners;

namespace Prueba_de_ASP.NET.Controllers.Owners
{
    [ApiController]
    [Route("[controller]")]
    public class OwnersController : ControllerBase
    {
       private readonly IOwnersRepository _ownersRepository;
       public OwnersController(IOwnersRepository ownersRepository)
       {
           _ownersRepository = ownersRepository;
       }

       [HttpGet("List")]
       public IEnumerable<Owner> GetOwners()
       {
            try
            {
                return _ownersRepository.GetOwners();
            }
            catch
            {
                return (IEnumerable<Owner>)BadRequest("Error getting owners");
            }
       }

       [HttpGet("List/{id}")]
       public Owner GetOwnerById(int id)
       {
            var Owner = _ownersRepository.GetOwner(id);
            if(!ModelState.IsValid)
            {
                NotFound("Owner not found");
            }
            
            return Owner;
       }
    }
}