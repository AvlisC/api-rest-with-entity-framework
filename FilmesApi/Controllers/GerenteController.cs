using FilmesApi.Data.Gerente_DTOs;
using FilmesApi.Models;
using FilmesApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GerenteController : ControllerBase
    {
        private GerenteService _service;

        public GerenteController(GerenteService service)
        {
            _service = service; 
        }

        [HttpPost("InsereGerente")]
        public IActionResult InserirGerente([FromBody] CreateGerenteDto gerenteDto)
        {
            var gerente = _service.InserirGerente(gerenteDto);
            return CreatedAtAction(nameof(RecuperaNomesGerentes), new { Id = gerente.Id }, gerente);
        }

        [HttpGet("RecuperaTodosGerentes")]
        public IEnumerable<Gerente> RecuperaNomesGerentes()
        {
            return _service.RecuperaNomesGerentes();
        }

        [HttpGet("RecuperaGerentePor/{id}")]
        public IActionResult RecuperaGerentePorId(int id)
        {
            var gerente = _service.RecuperaGerentePorId(id);
            if (gerente != null) return Ok(gerente);
            return NotFound("ID NÃO ENCONTRADO");
        }

        [HttpDelete("DeletaGerente/{id}")]
        public IActionResult DeletaGerente(int id)
        {
            var gerente = _service.DeletaGerente(id);
            if (gerente.IsFailed) return NotFound();
            return NoContent();
        }

    }
}
