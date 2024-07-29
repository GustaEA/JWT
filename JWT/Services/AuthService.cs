using JWT.Data;
using JWT.Dtos;
using JWT.Models;
using JWT.Services.PasswordService;
using Microsoft.EntityFrameworkCore;

namespace JWT.Services
{
    public class AuthService : IAuthInterface
    {
        private readonly AppDbContext _context;
        private readonly IPasswordInterface _passwordInterface;
        public AuthService(AppDbContext context, IPasswordInterface passwordInterface)
        {
            this._context = context;
            this._passwordInterface = passwordInterface;
        }

        public async Task<Response<UsuarioDto>> Register(UsuarioDto usuarioRegistro)
        {
            Response<UsuarioDto> responseService = new Response<UsuarioDto>();

            try
            {
                if(!VerifyIfUserExist(usuarioRegistro))
                {
                    responseService.Data = null;
                    responseService.Message = "Usuário ou Email já cadastrados!";
                    responseService.Status = false;
                    return responseService;
                }

                _passwordInterface.GeneratePasswordHash(usuarioRegistro.Password, out byte[] passwordHash, out byte[] passwordSalt);

                UsuarioModel usuario = new UsuarioModel()
                {
                    User = usuarioRegistro.User,
                    Email = usuarioRegistro.Email,
                    Cargo = usuarioRegistro.Cargo,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };

                _context.Add(usuario);
                await _context.SaveChangesAsync();
                responseService.Message = "Usuário criado com sucesso!";
            }
            catch (Exception ex)
            {

                responseService.Data = null;
                responseService.Message = ex.Message;
                responseService.Status = false;
            }

            return responseService;
        }

        public async Task<Response<string>> Login(UsuarioLoginDto usuarioLogin)
        {
            Response<string> responseService = new Response<string>();

            try
            {
                var user = await _context.Usuario.FirstOrDefaultAsync(userBanco => userBanco.Email.Equals(usuarioLogin.Email));
                if (user == null)
                {
                    responseService.Data = null;
                    responseService.Message = "Credenciais inválidas";
                    responseService.Status = false;
                    return responseService;
                }

                if (!_passwordInterface.VerifyPasswordHash(usuarioLogin.Password, user.PasswordSalt, user.PasswordHash))
                {
                    responseService.Data = null;
                    responseService.Message = "Credenciais inválidas";
                    responseService.Status = false;
                    return responseService;
                }

                var token = _passwordInterface.GenerateToken(user);
                responseService.Data = token;
                responseService.Message = "Usuário logado com sucesso";
            }
            catch (Exception ex)
            {
                responseService.Data = null;
                responseService.Message = ex.Message;
                responseService.Status = false;
            }
            return responseService;
        }


         bool VerifyIfUserExist(UsuarioDto usuario)
        {
            var user = _context.Usuario.FirstOrDefault(userBanco => userBanco.User.Equals(usuario.User) || userBanco.Email.Equals(usuario.Email));
            if (user != null)
                return false;

            return true;
        }
    }
}
