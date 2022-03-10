using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Models;
using FilmesAPI.Data;
using FilmesAPI.Data.Cinema_Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private ProjetoContext _context;
        private IMapper _mapper;

        public CinemaController(ProjetoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
  
        [HttpPost("InsereCinema")]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinema.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaCinemaPorId), new { Id = cinema.Id }, cinema);
        }

        [HttpGet("RecuperaNomeCinemas")]
        public IEnumerable<Cinema> RecuperaCinema()
        {
            return _context.Cinema;
        }

        [HttpGet("RecuperaCinemaPor{id}")]
        public IActionResult RecuperaCinemaPorId(int id)
        {
            Cinema cinema = _context.Cinema.FirstOrDefault(cinema => cinema.Id == id);
            if(cinema != null)
            {
                ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);

                return Ok(cinemaDto);
            }
            return NotFound();
        }

        [HttpPut("AtualizaCinema/{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Cinema cinema = _context.Cinema.FirstOrDefault(cinema => cinema.Id == id);
            if(cinema == null)
            {
                return NotFound();
            }
            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Cinema cinema = _context.Cinema.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }
            _context.Remove(cinema);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
