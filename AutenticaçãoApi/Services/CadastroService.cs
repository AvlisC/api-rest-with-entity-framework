using AutenticaçãoApi.Data;
using AutenticaçãoApi.Data.Dtos;
using System;
using FluentResults;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using AutenticaçãoApi.Models;
using System.Threading.Tasks;

namespace AutenticaçãoApi.Services
{
    public class CadastroService
    {
        private UserDbContext _context;
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _manager;

        public CadastroService(UserDbContext context, IMapper mapper, UserManager<IdentityUser<int>> manager)
        {
            _context = context;
            _mapper = mapper;
            _manager = manager;
        }

        public Result CadastraUsuario(CreateUsuarioDto createDto)
        {
            //Map<destination>(source)
            Usuarios usuario = _mapper.Map<Usuarios>(createDto);
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
            Task<IdentityResult> resultadoIdentity = _manager.CreateAsync(usuarioIdentity, createDto.Password);
            if (resultadoIdentity.Result.Succeeded) return Result.Ok();
            return Result.Fail("Falha ao cadastrar usuário.");

        }
    }
}
