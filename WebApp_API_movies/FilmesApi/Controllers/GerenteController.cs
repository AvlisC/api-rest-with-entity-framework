using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Gerente_DTOs;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private IMapper _mapper;
        private ProjetoContext _context;

        public GerenteController(ProjetoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("InsereGerente")]
        public IActionResult InserirGerente([FromBody] CreateGerenteDto gerenteDto)
        {
            var gerenteMapper = _mapper.Map<Gerente>(gerenteDto);
            _context.Gerente.Add(gerenteMapper);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaNomesGerentes), new { Id = gerenteMapper.Id }, gerenteMapper);
        }

        [HttpGet("RecuperaTodosGerentes")]
        public IEnumerable<Gerente> RecuperaNomesGerentes()
        {
            return _context.Gerente;
        }

        [HttpGet("RecuperaGerentePor{id}")]
        public IActionResult RecuperaGerentePorId(int id)
        {
            var percorreGerentes = _context.Gerente.FirstOrDefault(gerente => gerente.Id == id);
            if(percorreGerentes != null)
            {
                var gerenteMapper = _mapper.Map<ReadGerenteDto>(percorreGerentes);

                return Ok(gerenteMapper);
            }
            return NotFound();
        }

        [HttpDelete("DeletaGerente/{id}")]
        public IActionResult DeletaGerente(int id)
        {
            var percorreGerentes = _context.Gerente.FirstOrDefault(gerente => gerente.Id == id);
            if (percorreGerentes == null)
            {
                return NotFound();
            }
            _context.Remove(percorreGerentes);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
