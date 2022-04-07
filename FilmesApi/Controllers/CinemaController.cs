using FilmesApi.Services;
using FilmesAPI.Data.Cinema_Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CinemaController : ControllerBase
    {
        private CinemaService _cinemaService;

        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }
        
        [HttpPost("InsereCinema")]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            var readDto = _cinemaService.AdicionaCinema(cinemaDto);
            return CreatedAtAction(nameof(RecuperaCinemaPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet("RecuperaNomeCinemas")]
        public IActionResult RecuperaCinemas([FromQuery] string nomeFilme)
        {
            List<ReadCinemaDto> readDto = _cinemaService.RecuperaCinemas(nomeFilme);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpGet("RecuperaCinemaPor/{id}")]
        public IActionResult RecuperaCinemaPorId(int id)
        {
            var cinema = _cinemaService.RecuperaCinemaId(id);
            if(cinema != null) return Ok(cinema); 
            return NotFound("ID NÃO ENCONTRADO");
        }

        [HttpPut("AtualizaCinema/{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
           var result = _cinemaService.AtualizaCinema(id, cinemaDto);
            if(result.IsFailed) return NotFound("ID NÃO ENCONTRADO");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            var result = _cinemaService.DeletaCinema(id);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }

    }
}
