using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Models
{
    public class Sessao
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int CinemaId { get; set; }
        public virtual Cinema Cinema { get; set; }
        public int FilmeId { get; set; }
        public virtual Filme Filme { get; set; }
        public DateTime HoraEncerramento { get; set; }


    }
}
