
using Prueba_de_ASP.NET.Models;
using Prueba_de_ASP.NET.DTOs;
using AutoMapper;

namespace Prueba_de_ASP.NET.Utils
{
    public class OwnerProfile : Profile
    {
        public OwnerProfile()
        {
            CreateMap<OwnerDto, Owner>().
            ForAllMembers(options => options.
            Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}