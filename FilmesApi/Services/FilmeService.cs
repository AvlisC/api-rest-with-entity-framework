using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Models;
using FilmesAPI.Data.Filme_Dtos;
using FluentResults;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApi.Services
{
    public class FilmeService
    {
        private IMapper _mapper;
        private ProjetoContext _context;

        public FilmeService(ProjetoContext projetoContext, IMapper mapper)
        {
            _mapper = mapper;
            _context = projetoContext;
        }

        public ReadFilmeDto AdicionarFilme(CreateFilmeDto createDto)
        {
            Filme filme = _mapper.Map<Filme>(createDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return _mapper.Map<ReadFilmeDto>(filme);
        }
        public List<ReadFilmeDto> RecuperaFilme(int? faixaEtaria = null)
        {
            List<Filme> filmes;
            if (faixaEtaria == null)
            {
                filmes = _context.Filmes.ToList();
            }
            else
            {
                filmes = _context
                    .Filmes
                    .Where(filme => filme.FaixaEtaria <= faixaEtaria)
                    .ToList();
            }

            if(filmes != null)
            {
                var recuperaFilme = _mapper.Map<List<ReadFilmeDto>>(filmes);
                return recuperaFilme;
            }
            return null;
        }

        public ReadFilmeDto RecuperaFilmePorId(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null) 
            { 
                return _mapper.Map<ReadFilmeDto>(filme); 
            }
            return null;
        }

        public Result AtualizaFilme(int id, UpdateFilmeDto filmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return Result.Fail("Filme não encontrado.");
            }
            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme == null)
            {
                return Result.Fail("Filme não encontrado.");
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
