

using Prueba_de_ASP.NET.Data;
using Prueba_de_ASP.NET.Models;

namespace Prueba_de_ASP.NET.Services.Pets
{
    public class PetsRepository : IPetsRepository
    {
        private readonly BaseContext _baseContext;
        public PetsRepository(BaseContext baseContext)
        {
            _baseContext = baseContext;
        }

        public void CreatePet(Pet pet)
        {
            _baseContext.Pets.Add(pet);
            _baseContext.SaveChanges();
        }

        public void DeletePet(int id)
        {
            throw new NotImplementedException();
        }

        public Pet GetPet(int id)
        {
            var pet = _baseContext.Pets.FirstOrDefault(o => o.Id == id);
            return pet;
        }

        public IEnumerable<Pet> GetPets()
        {
            var pets = _baseContext.Pets.ToList();
            return pets;
        }

        public void UpdatePet(int id, Pet pet)
        {
            var petUpdate = _baseContext.Pets.FirstOrDefault(o => o.Id == id);

            petUpdate.Name = pet.Name;
            petUpdate.Specie = petUpdate.Specie;
            petUpdate.Race = pet.Race;
            petUpdate.DateBirth = pet.DateBirth;
            petUpdate.OwnerId = pet.OwnerId;
            petUpdate.Photo = pet.Photo;

            _baseContext.Update(petUpdate);
            _baseContext.SaveChanges();
        }
    }
}