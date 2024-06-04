

using Prueba_de_ASP.NET.Data;
using Prueba_de_ASP.NET.Models;

namespace Prueba_de_ASP.NET.Services.Owners
{
    public class OwnersRepository : IOwnersRepository
    {
        private readonly BaseContext _baseContext;
        public OwnersRepository(BaseContext baseContext)
        {
            _baseContext = baseContext;
        }

        public void CreateOwner(Owner owner)
        {
            _baseContext.Owners.Add(owner);
            _baseContext.SaveChanges();
        }

        public void DeleteOwner(int id)
        {
            throw new NotImplementedException();
        }

        public Owner GetOwner(int id)
        {
            var owner = _baseContext.Owners.FirstOrDefault(o => o.Id == id);
            return owner;
        }

        public IEnumerable<Owner> GetOwners()
        {
            var owners = _baseContext.Owners.ToList();
            return owners;
        }

        public void UpdateOwner(int id, Owner owner)
        {
            var OwnerUpdate = _baseContext.Owners.FirstOrDefault(o => o.Id == id);

            OwnerUpdate.Names = owner.Names;
            OwnerUpdate.LastNames = owner.LastNames;
            OwnerUpdate.Email = owner.Email;
            OwnerUpdate.Address = owner.Address;
            OwnerUpdate.Phone = owner.Phone;

            _baseContext.Update(OwnerUpdate);
            _baseContext.SaveChanges();
        }
    }
}