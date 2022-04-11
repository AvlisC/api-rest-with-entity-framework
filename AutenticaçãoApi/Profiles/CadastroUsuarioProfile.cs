using AutenticaçãoApi.Data.Dtos;
using AutenticaçãoApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AutenticaçãoApi.Profiles
{
    public class CadastroUsuarioProfile : Profile
    {
        public CadastroUsuarioProfile()
        {   //CreateMap<source, destination>
            CreateMap<CreateUsuarioDto, Usuarios>();
            CreateMap<Usuarios, IdentityUser<int>>();
        }
    }
}

