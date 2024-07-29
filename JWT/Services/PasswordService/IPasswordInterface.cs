using JWT.Models;

namespace JWT.Services.PasswordService
{
    public interface IPasswordInterface
    {
        void GeneratePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(string password, byte[] passwordSalt, byte[] passwordHash);
        string GenerateToken(UsuarioModel usuario);
    }
}
