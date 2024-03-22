using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using GerenciamentoBiblioteca.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GerenciamentoBiblioteca.Data;


namespace GerenciamentoBiblioteca.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly bibliotecaDBContext _context;

        public LoginController(bibliotecaDBContext context)
        {
            _context = context;
        }
        
       [HttpPost]
        
        public IActionResult Login([FromBody] loginModel login)
        {
            
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == login.Login && u.Senha == login.Senha);

            if (login.Login == "Vinicius" && login.Senha == "1234")
            {
                var token = GerarToken();
                return Ok(new { token });
            }
            return BadRequest(new { mensagem = "Credenciais inválidas. Por favor, verifique e tente novamente." });
        }

        private string GerarToken()
        {
            string chaveSecreta = "389eb5f3-0eff-4f87-b053-40ec277ae181";

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta));
            var credencial = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("login", "admin"),
                new Claim("Nome", "Administrador do Sistema")
            };

            var token = new JwtSecurityToken(
                issuer: "empresa",//emissor do token
                audience: "aplicacao",//destinatário= aplicação que irá usar o token
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credencial
             );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}