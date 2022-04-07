using FilmesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Data.Sessao_DTOs
{
    public class ReadSessaoDto
    {
        public int Id { get; set; }
        public Cinema cinema { get; set; }
        public Filme Filme { get; set; }
        public DateTime HoraEncerramento { get; set; }
        public DateTime HorarioDeInicio { get; set; }
    }
}
