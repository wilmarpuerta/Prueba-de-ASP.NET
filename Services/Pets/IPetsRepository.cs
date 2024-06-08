
using Prueba_de_ASP.NET.Models;

namespace Prueba_de_ASP.NET.Services.Pets
{
    public interface IPetsRepository
    {
        IEnumerable<Pet> GetPets();
        IEnumerable<Pet> GetPetsByOwner(int id);
        IEnumerable<Pet> GetPetsByDate(DateOnly date);
        Pet GetPet(int id);
        void CreatePet(Pet pet);
        void UpdatePet(int id, Pet pet);
    }
}