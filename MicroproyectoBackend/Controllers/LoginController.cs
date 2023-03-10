using MediatR;
using MicroproyectoBackend.Aplication.Commands;
using MicroproyectoBackend.Infraestructure.Entities;
using MicroproyectoBackend.Infraestructure.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MicroproyectoBackend.ApiRest.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {       

        private readonly ILogger<UsersController> _logger;
        private readonly IMediator _mediator;
        //private readonly IJwtAuthManager _jwtAuthManager;

        public LoginController(ILogger<UsersController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<List<User>>> Login()
        {
            //if (login.Usuario == "usuario" && login.Password == "password")
            
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("tu_clave_secreta"));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    issuer: "tu_issuer",
                    audience: "tu_audience",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signingCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString });
                //    var command = new LoginCommand();
                //return new UnauthorizedResult();
                //var response = await _mediator.Send(command);
                //return Ok(response);

            //}
        }
    }
}