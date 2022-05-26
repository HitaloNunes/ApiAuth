using ApiAuth.Model;
using ApiAuth.Repositories;
using ApiAuth.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiAuth.Controllers
{
    [Route("v1")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] User model)
        {
            //Recupera o Usuário
            var user = UserRepository.Get(model.UserName, model.Password);

            //Verifica se o usuário existe
            if(user == null)
            {
                return NotFound(new { message = "Usuário ou senha inválidos" });
            }

            //Gera o Token
            var token = TokenService.GenerateToken(user);

            //Oculpa a senha
            user.Password = "";

            //Retorna os dados
            return new 
            {
                user = user,
                token = token
            };
        }
    }
}
