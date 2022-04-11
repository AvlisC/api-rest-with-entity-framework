using System.ComponentModel.DataAnnotations;

namespace AutenticaçãoApi.Models
{
    public class Usuarios
    {   
        [Required]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }              
    }
}
