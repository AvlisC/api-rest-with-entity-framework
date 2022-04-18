using AutenticaçãoApi.Data.Requests;
using FluentResults;
using Microsoft.AspNetCore.Identity;


namespace AutenticaçãoApi.Models
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;

        public LoginService(SignInManager<IdentityUser<int>> signInManager)
        {
            _signInManager = signInManager;
        }
        public Result LogarUsuario(LoginRequest request)
        {
            var resultado = _signInManager
                .PasswordSignInAsync(request.Username, request.Password, false, false);
            if (resultado.Result.Succeeded) return Result.Ok();
            return Result.Fail("Login inválido.");
        }
    }
}
