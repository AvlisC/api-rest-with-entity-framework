﻿using AutoMapper;
using FilmesApi.Data.Gerente_DTOs;
using FilmesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDto, Gerente>();
            CreateMap<Gerente, ReadGerenteDto>()
                .ForMember(gerente => gerente.Cinemas, opt => opt
                .MapFrom(gerente => gerente.Cinemas.Select(c => new { c.Id, c.Nome, c.EnderecoId, c.Endereco})));
        }
    }
}
