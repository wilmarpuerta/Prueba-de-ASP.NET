
using AutoMapper;
using Prueba_de_ASP.NET.Data;
using Prueba_de_ASP.NET.DTOs;
using Prueba_de_ASP.NET.Models;

namespace Prueba_de_ASP.NET.Services.Owners
{
    public class OwnersRepository : IOwnersRepository
    {
        private readonly BaseContext _baseContext;
        private readonly IMapper _mapper;
        public OwnersRepository(BaseContext baseContext, IMapper mapper)
        {
            _baseContext = baseContext;
            _mapper = mapper;
        }

        public void CreateOwner(Owner owner)
        {
            _baseContext.Owners.Add(owner);
            _baseContext.SaveChanges();
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

        public void UpdateOwner(int id, OwnerDto owner)
        {
            var OwnerUpdate = _baseContext.Owners.FirstOrDefault(o => o.Id == id);

            _mapper.Map(owner, OwnerUpdate);
            _baseContext.SaveChanges();
        }
    }
}