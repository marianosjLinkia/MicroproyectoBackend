using MediatR;
using MicroproyectoBackend.ApiRest.Request;
using MicroproyectoBackend.Aplication.Commands;
using MicroproyectoBackend.Infraestructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MicroproyectoBackend.ApiRest.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {       

        private readonly ILogger<UsersController> _logger;
        private readonly IMediator _mediator;

        public LoginController(ILogger<UsersController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<List<User>>> Login([FromBody] LoginRequest loginRequest)
        {            
            var command = new LoginCommand()
            { 
                Email = loginRequest.Email,
                Password = loginRequest.Password
            };

            var tokenString = await _mediator.Send(command);

            if (tokenString == null)
            {
                new UnauthorizedResult();
            }

            return  Ok(new { Token = tokenString });
        }
    }
}