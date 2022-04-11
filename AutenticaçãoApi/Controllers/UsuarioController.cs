using AutenticaçãoApi.Data.Dtos;
using AutenticaçãoApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutenticaçãoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private CadastroService _service;

        public UsuarioController(CadastroService service)
        {
            _service = service;
        }
        [HttpPost("CriarUsuario")]
        public IActionResult CriarUsuario([FromBody]CreateUsuarioDto criarUserDto)
        {
            Result resultado = _service.CadastraUsuario(criarUserDto);
            if (resultado.IsFailed) return StatusCode(500);
            return Ok("Usuário cadastrado com sucesso!");
        }
    }
}
