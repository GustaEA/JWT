using System.ComponentModel.DataAnnotations;

namespace JWT.Dtos
{
    public class UsuarioLoginDto
    {
        [Required(ErrorMessage = "O campo Email é obrigatório"), EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo senha é obrigatório")]
        public string Password { get; set; }
    }
}
