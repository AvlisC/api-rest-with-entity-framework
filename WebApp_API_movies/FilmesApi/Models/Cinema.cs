using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FilmesApi.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
        [JsonIgnore]
        public virtual Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }//FK
        public virtual Gerente Gerente { get; set; }
        public int GerenteId { get; set; }//FK
        public virtual List<Sessao> Sessoes { get; set; }

    }
}
