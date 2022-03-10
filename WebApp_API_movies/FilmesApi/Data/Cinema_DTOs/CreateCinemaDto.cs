using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.Cinema_Dtos
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }
        [Required]
        public int EnderecoId { get; set; }
        [Required]
        public int GerenteId { get; set; }
    }
}
