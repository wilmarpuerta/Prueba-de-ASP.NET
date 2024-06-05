

using Prueba_de_ASP.NET.Models;

namespace Prueba_de_ASP.NET.Services.Vets
{
    public interface IVetsRepository
    {
        IEnumerable<Vet> GetVets();
        Vet GetVet(int id);
        void CreateVet(Vet vet);
    }
}