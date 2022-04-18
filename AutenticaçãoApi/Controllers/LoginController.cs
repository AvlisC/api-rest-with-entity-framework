using AutenticaçãoApi.Data.Requests;
using AutenticaçãoApi.Models;
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
    public class LoginController : ControllerBase
    {
        private LoginService _service;

        public LoginController(LoginService service)
        {
            _service = service;
        }
        [HttpPost("LoginUsuario")]
        public IActionResult LoginUsuario(LoginRequest request)
        {
            Result resultado = _service.LogarUsuario(request);
            if (resultado.IsFailed) return Unauthorized();
            return Ok("Login Efetuado com sucesso!");
        }   
    }
}
