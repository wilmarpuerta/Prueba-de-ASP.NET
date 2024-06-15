
using Prueba_de_ASP.NET.Models;
using Prueba_de_ASP.NET.DTOs;
using AutoMapper;

namespace Prueba_de_ASP.NET.Utils
{
    public class PetProfile : Profile
    {
        public PetProfile()
        {
            CreateMap<PetDto, Pet>().
            ForAllMembers(optonst => optonst.
            Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}