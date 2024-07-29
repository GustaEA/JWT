using JWT.Enum;

namespace JWT.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Email { get; set; }
        public CargoEnum Cargo { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime DateCreationToken { get; set; } = DateTime.Now;
    }
}
