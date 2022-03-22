using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Models;
using FilmesAPI.Data.Filme_Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Services
{
    public class FilmeService
    {
        private IMapper _mapper;
        private ProjetoContext _context;

        public FilmeService(ProjetoContext projetoContext, IMapper mapper)
        {
            _mapper = _mapper;
            _context = projetoContext;
        }

        public List<ReadFilmeDto> AdicionarFilme(CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return ma
        }

    }
}
