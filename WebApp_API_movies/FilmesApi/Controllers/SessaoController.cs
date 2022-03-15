using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Sessao_DTOs;
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
    public class SessaoController : ControllerBase
    {
        private ProjetoContext _context;
        private IMapper _mapper;

        public SessaoController(ProjetoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult InsereSessao([FromBody] CreateSessaoDto createSessao)
        {
            var sessaoMapper = _mapper.Map<Sessao>(createSessao);
            _context.Sessoes.Add(sessaoMapper);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaSessoes), new { Id = sessaoMapper.Id }, sessaoMapper);
            
        }

        [HttpGet("RecuperaTodasSessoes")]
        public IActionResult RecuperaSessoes()
        {
            return Ok(_context.Sessoes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessoesPorId(int id)
        {
            var sessoes = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessoes != null)
            {
                ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessoes);

                return Ok(sessaoDto);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaSessao(int id)
        {
            var sessoes = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if(sessoes != null)
            {
                return NotFound();
            }
            _context.Sessoes.Remove(sessoes);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

