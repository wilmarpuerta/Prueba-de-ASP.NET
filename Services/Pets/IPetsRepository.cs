
using Prueba_de_ASP.NET.Models;

namespace Prueba_de_ASP.NET.Services.Pets
{
    public interface IPetsRepository
    {
        IEnumerable<Pet> GetPets();
        Pet GetPet(int id);
        void CreatePet(Pet pet);
        void UpdatePet(int id, Pet pet);
        void DeletePet(int id);
    }
}