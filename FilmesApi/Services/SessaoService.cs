using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Sessao_DTOs;
using FilmesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApi.Services
{
    public class SessaoService
    {
        private IMapper _mapper;
        private ProjetoContext _context;

        public SessaoService(IMapper mapper, ProjetoContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public ReadSessaoDto InsereSessao(CreateSessaoDto createSessao)
        {
            var sessao = _mapper.Map<Sessao>(createSessao);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return _mapper.Map<ReadSessaoDto>(sessao);
        }

        public ReadSessaoDto RecuperaSessoesPorId(int id)
        {
            var sessoes = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            if (sessoes != null)
            {
                return _mapper.Map<ReadSessaoDto>(sessoes);
            }
            return null;
        }

        public IEnumerable<Sessao> RecuperaTodasSessoes()
        {
            return _context.Sessoes;
        }
    }

}
