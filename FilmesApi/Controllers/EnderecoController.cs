using FilmesApi.Models;
using FilmesApi.Services;
using FilmesAPI.Data.Endereco_Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EnderecoController : ControllerBase
    {
        private EnderecoService _service;

        public EnderecoController(EnderecoService service)
        {
            _service = service;
        }

        [HttpPost("InsereEndereco")]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            var readDto = _service.AdicionaEndereco(enderecoDto);
            return CreatedAtAction(nameof(RecuperaEnderecoPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet("RecuperaTodosEnderecos")]
        public IEnumerable<Endereco> RecuperaCinema()
        {
            return _service.RecuperaEndereco();
        }

        [HttpGet("RecuperaEndereco/{id}")]
        public IActionResult RecuperaEnderecoPorId(int id)
        {
            var readDto = _service.RecuperaEnderecoPorId(id);
            if (readDto != null) return Ok(readDto);
            return NotFound("ID NÃO ENCONTRADO");
        }

        [HttpPut("AtualizaEndereco/{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            var resultUpdateDto = _service.AtualizaEndereco(id, enderecoDto);
            if (resultUpdateDto.IsFailed) return NotFound("ID NÃO ENCONTRADO");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            var resultDeletaEndereco = _service.DeletaEndereco(id);
            if (resultDeletaEndereco.IsFailed) return NotFound();
            return NoContent();
        }

    }
}
