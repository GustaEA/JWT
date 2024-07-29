using JWT.Dtos;
using JWT.Models;

namespace JWT.Services
{
    public interface IAuthInterface
    {
        Task<Response<UsuarioDto>> Register(UsuarioDto usuarioRegistro);
        Task<Response<string>> Login(UsuarioLoginDto usuarioLogin);
    }
}
