using FilmesApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Data.Gerente_DTOs
{
    public class ReadGerenteDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }
        public object Cinemas { get; set; }//objeto anônimo não recebe um tipo especifico, é como um membro vazio
        public DateTime HoraDaConsulta { get; set; } = DateTime.Now;

    }
}
