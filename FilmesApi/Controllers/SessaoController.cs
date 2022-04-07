using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Sessao_DTOs;
using FilmesApi.Models;
using FilmesApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessaoController : ControllerBase
    {
        private SessaoService _service;

        public SessaoController(SessaoService service)
        {
            _service = service;
        }

        [HttpPost("InsereSessao")]
        public IActionResult InsereSessao([FromBody] CreateSessaoDto createSessao)
        {
            var sessao = _service.InsereSessao(createSessao);
            return CreatedAtAction(nameof(RecuperaSessoesPorId), new { Id = sessao.Id }, sessao);
            
        }

        [HttpGet("RecuperaTodasSessoes")]
        public IEnumerable<Sessao> RecuperaTodasSessoes()
        {
            return _service.RecuperaTodasSessoes();
        }

        [HttpGet("RecuperaSessoes/{id}")]
        public IActionResult RecuperaSessoesPorId(int id)
        {
            var sessao = _service.RecuperaSessoesPorId(id);
            if (sessao != null) return Ok(sessao);
            return NotFound("ID NÃO ENCONTRADO");
        }

    }
}

