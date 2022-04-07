using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Models;
using FilmesAPI.Data.Cinema_Dtos;
using FluentResults;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApi.Services
{
    public class CinemaService 
    {
        private IMapper _mapper;
        private ProjetoContext _context;

        public CinemaService(IMapper mapper, ProjetoContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        
        public ReadCinemaDto AdicionaCinema(CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinema.Add(cinema);
            _context.SaveChanges();
            return _mapper.Map<ReadCinemaDto>(cinema);
        }

        public List<ReadCinemaDto> RecuperaCinemas(string nomeFilme)
        {
            List<Cinema> cinemas = _context.Cinema.ToList();
            if(cinemas == null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(nomeFilme))
            {
                IEnumerable<Cinema> query = from cinema in cinemas
                                            where cinema.Sessoes.Any(sessao => sessao.Filme.Titulo == nomeFilme)
                                            select cinema;
                cinemas = query.ToList();
            }
            return _mapper.Map<List<ReadCinemaDto>>(cinemas);
        }

        public ReadCinemaDto RecuperaCinemaId(int id)
        {
            Cinema cinema = _context.Cinema.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema != null)
            {
                return _mapper.Map<ReadCinemaDto>(cinema);
            }
            return null;
        }

        public Result AtualizaCinema(int id, UpdateCinemaDto cinemaDto)
        {
            Cinema cinema = _context.Cinema.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return Result.Fail("cinema não encontrado.");
            }
            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaCinema(int id)
        {
            Cinema cinema = _context.Cinema.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return Result.Fail("Cinema não encontrado.");
            }
            _context.Remove(cinema);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
