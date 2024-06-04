

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
            throw new NotImplementedException();
        }

        public IEnumerable<Owner> GetOwners()
        {
            throw new NotImplementedException();
        }

        public void UpdateOwner(int id, Owner owner)
        {
            throw new NotImplementedException();
        }
    }
}