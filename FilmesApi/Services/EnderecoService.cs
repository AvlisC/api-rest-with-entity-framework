using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Models;
using FilmesAPI.Data.Endereco_Dtos;
using FluentResults;
using System.Collections.Generic;
using System.Linq;

namespace FilmesApi.Services
{
    public class EnderecoService
    {
        private IMapper _mapper;
        private ProjetoContext _context;

        public EnderecoService(IMapper mapper, ProjetoContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public ReadEnderecoDto AdicionaEndereco(CreateEnderecoDto enderecoDto)
        {
            var endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Endereco.Add(endereco);
            _context.SaveChanges();
            return _mapper.Map<ReadEnderecoDto>(endereco);
        }

        public IEnumerable<Endereco> RecuperaEndereco()
        {
            return _context.Endereco;
        }

        public ReadEnderecoDto RecuperaEnderecoPorId(int id)
        {
            Endereco endereco = _context.Endereco.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco != null)
            {
                ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);

                return enderecoDto;
            }
            return null;
        }

        public Result AtualizaEndereco(int id, UpdateEnderecoDto enderecoDto)
        {
            Endereco endereco = _context.Endereco.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                return Result.Fail("Id não foi encontrado");
            }
            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaEndereco(int id)
        {
            Endereco endereco = _context.Endereco.FirstOrDefault(Endereco => Endereco.Id == id);
            if (endereco == null)
            {
                return Result.Fail("Endereço não encontrado.");
            }
            _context.Remove(endereco);
            _context.SaveChanges();
            return Result.Ok();

        }
    }
}
