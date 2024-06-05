
using Microsoft.AspNetCore.Mvc;
using Prueba_de_ASP.NET.Models;
using Prueba_de_ASP.NET.Services.Vets;

namespace Prueba_de_ASP.NET.Controllers.Vets
{
    [ApiController]
    [Route("api/vets")]
    public class VetsController : ControllerBase
    {
        private readonly IVetsRepository _vetsRepository;
        public VetsController(IVetsRepository vetsRepository)
        {
            _vetsRepository = vetsRepository;
        }
        [HttpGet]
        public IEnumerable<Vet> GetVets()
        {
            try
            {
               return _vetsRepository.GetVets();
            }
            catch
            {
                return (IEnumerable<Vet>)BadRequest("Error getting owners");
            }
        }

        [HttpGet("{id}")]
        public Vet GetVetById(int id)
        {
            var Vet = _vetsRepository.GetVet(id);
            if(!ModelState.IsValid)
            {
                NotFound("Vet not found");
            }
            return Vet;
        }
    }
}