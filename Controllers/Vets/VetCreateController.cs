
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Prueba_de_ASP.NET.Models;
using Prueba_de_ASP.NET.Services.Vets;

namespace Prueba_de_ASP.NET.Controllers.Vets
{
    [ApiController]
    [Route("api/vets")]
    public class VetCreateController : ControllerBase
    {
        private readonly IVetsRepository _vetsRepository;
        public VetCreateController(IVetsRepository vetsRepository)
        {
            _vetsRepository = vetsRepository;
        }
        [HttpPost]
        public IActionResult Create([FromBody] Vet vet)
        {
            try
            {
                _vetsRepository.CreateVet(vet);
                return Ok("Vet created successfully");
            }
            catch
            {
                return BadRequest("Error creating owner");
            }
        }

    }
}