using FilmesApi.Services;
using FilmesAPI.Data.Filme_Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeService _filmeService;

        public FilmeController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }
  
        [HttpPost("InsereFilme")]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            var readDto = _filmeService.AdicionarFilme(filmeDto);
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet("RecuperaTodosFilmes")]
        public IActionResult RecuperaFilmes([FromQuery] int? faixaEtaria = null)
        {
            var readDto = _filmeService.RecuperaFilme(faixaEtaria);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpGet("RecuperaFilme/{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            var readDto = _filmeService.RecuperaFilmePorId(id);
            if (readDto != null) return Ok(readDto);
            return NotFound("ID NÃO ENCONTRADO");
        }

        [HttpPut("AtualizaFilme/{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            var result = _filmeService.AtualizaFilme(id, filmeDto);
            if (result.IsFailed) return NotFound("ID NÃO ENCONTRADO");
            return NoContent();
        }

        [HttpDelete("DeletarFilme/{id}")]
        public IActionResult DeletaFilme(int id)
        {
            var result = _filmeService.DeletaFilme(id);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
