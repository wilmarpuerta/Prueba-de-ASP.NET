
using Prueba_de_ASP.NET.DTOs;
using Prueba_de_ASP.NET.Models;

namespace Prueba_de_ASP.NET.Services.Owners
{
    public interface IOwnersRepository
    {
        IEnumerable<Owner> GetOwners();
        Owner GetOwner(int id);
        void CreateOwner(Owner owner);
        void UpdateOwner(int id, OwnerDto owner);
    }
}