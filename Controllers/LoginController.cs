using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoApi.Data;
using MongoApi.Model;
//using MongoApi.Service;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;


namespace MongoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private readonly DBContext _dbContext;
        //private readonly LoginService _loginService;
        private IConfiguration _configuration; 

        public LoginController(DBContext dbContext, IConfiguration configuration)//, LoginService loginService)
        {
            //this._loginService = loginService;
            this._dbContext = dbContext;
            this._configuration = configuration;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Login(UserModel user)
        {
            var admin = this._dbContext.User.FirstOrDefault(c => c.Name == user.Name && c.PSW == user.PSW);//FirstAsync(x => x.Name == user.Name && x.PSW == user.PSW); ;//await _loginService.GetUser(user);
            // credenciales
            if (admin == null) {
                return BadRequest(new { message = "credenciales invalidas"});
            }
            //Generar token
            string token = GenerateToeken(user);

            return Ok(new { token = token }); ;//Ok();
        }
        //metodo para generar token
        private string GenerateToeken(UserModel user) 
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email)
            };
            //obtengo el key para encriptar
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:KEY").Value));
            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha512);
            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds
                );
            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }

    }
}
