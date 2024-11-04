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

        public LoginController(DBContext dbContext)//, LoginService loginService)
        {
            //this._loginService = loginService;
            this._dbContext = dbContext;
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

            return Ok(new { message = "some value" }); ;//Ok();
        }

        private string GenerateToeken(UserModel user) 
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email)
            }
            var key = new SymmetricSecurityKey
        }

    }
}
