using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Gerente_DTOs;
using FilmesApi.Models;
using FluentResults;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApi.Services
{
    public class GerenteService
    {
        private IMapper _mapper;
        private ProjetoContext _context;

        public GerenteService(IMapper mapper, ProjetoContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public ReadGerenteDto InserirGerente(CreateGerenteDto gerenteDto)
        {
            var gerente = _mapper.Map<Gerente>(gerenteDto);
            _context.Gerente.Add(gerente);
            _context.SaveChanges();
            return _mapper.Map<ReadGerenteDto>(gerente);
        }

        public IEnumerable<Gerente> RecuperaNomesGerentes()
        {
            return _context.Gerente;
        }

        public ReadGerenteDto RecuperaGerentePorId(int id)
        {
            var percorreGerentes = _context.Gerente.FirstOrDefault(gerente => gerente.Id == id);
            if (percorreGerentes != null)
            {
                var gerenteMapper = _mapper.Map<ReadGerenteDto>(percorreGerentes);
                return gerenteMapper;
            }
            return null;
        }

        public Result DeletaGerente(int id)
        {
            var percorreGerentes = _context.Gerente.FirstOrDefault(gerente => gerente.Id == id);
            if (percorreGerentes == null)
            {
                return Result.Fail("Gerente não encontrado");
            }
            _context.Remove(percorreGerentes);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
