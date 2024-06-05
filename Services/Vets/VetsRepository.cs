
using Microsoft.EntityFrameworkCore;
using Prueba_de_ASP.NET.Data;
using Prueba_de_ASP.NET.Models;

namespace Prueba_de_ASP.NET.Services.Vets
{
    public class VetsRepository : IVetsRepository
    {
        private readonly BaseContext _baseContext;
        public VetsRepository(BaseContext baseContext)
        {
            _baseContext = baseContext;
        }
        public void CreateVet(Vet vet)
        {
            _baseContext.Vets.Add(vet);
            _baseContext.SaveChanges();
        }

        public Vet GetVet(int id)
        {
           var vet = _baseContext.Vets.FirstOrDefault(o => o.Id == id);
            return vet;
        }

        public IEnumerable<Vet> GetVets()
        {
            var vets = _baseContext.Vets.ToList();
            return vets;
        }
    }
}