using JWT.Enum;
using System.ComponentModel.DataAnnotations;

namespace JWT.Dtos
{
    public class UsuarioDto
    {
        [Required(ErrorMessage = "O campo usuário é obrigatório")]
        public string User { get; set; }
        [Required(ErrorMessage = "O campo Email é obrigatório"), EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo senha é obrigatório")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Senhas não coincidem")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "O campo cargo é obrigatório")]
        public CargoEnum Cargo { get; set; }
    }
}
