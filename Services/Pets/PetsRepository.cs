

using Microsoft.EntityFrameworkCore;
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

        public Pet GetPet(int id)
        {
            var pet = _baseContext.Pets.Include(p => p.Owner).FirstOrDefault(o => o.Id == id);
            return pet;
        }

        public IEnumerable<Pet> GetPets()
        {
            var pets = _baseContext.Pets.Include(p => p.Owner).ToList();
            return pets;
        }

        public IEnumerable<Pet> GetPetsByDate(DateOnly date)
        {
            var petsDate = _baseContext.Pets.Where(p => p.DateBirth == date).Include(o => o.Owner).ToList();
            return petsDate;
        }

        public IEnumerable<Pet> GetPetsByOwner(int id)
        {
            var petsOwner =_baseContext.Pets.Where(p => p.OwnerId == id).ToList();
            return petsOwner;
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