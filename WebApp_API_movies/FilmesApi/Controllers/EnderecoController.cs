using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Models;
using FilmesAPI.Data.Endereco_Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class EnderecoController : ControllerBase
    {
        private ProjetoContext _context;
        private IMapper _mapper;

        public EnderecoController(ProjetoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("InsereEndereco")]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            var endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Endereco.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaEnderecoPorId), new { Id = endereco.Id }, endereco);
        }

        [HttpGet("RecuperaNomeEnderecos")]
        public IEnumerable<Endereco> RecuperaCinema()
        {
            return _context.Endereco;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecoPorId(int id)
        { 
            Endereco endereco = _context.Endereco.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco != null)
            {
                ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);

                return Ok(enderecoDto);
            }
            return NotFound();
        }

        [HttpPut("AtualizaEndereco/{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            Endereco endereco = _context.Endereco.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }
            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            Endereco endereco = _context.Endereco.FirstOrDefault(Endereco => Endereco.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }
            _context.Remove(endereco);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
