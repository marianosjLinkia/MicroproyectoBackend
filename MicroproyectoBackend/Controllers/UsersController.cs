using MediatR;
using MicroproyectoBackend.Aplication.Commands;
using MicroproyectoBackend.Infraestructure.Entities;
using MicroproyectoBackend.Infraestructure.Enums;
using Microsoft.AspNetCore.Mvc;

namespace MicroproyectoBackend.ApiRest.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {       

        private readonly ILogger<UsersController> _logger;
        private readonly IMediator _mediator;

        public UsersController(ILogger<UsersController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("user")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {            
            var command = new GetUsersCommand();
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [Route("user/{userId}")]
        public async Task<ActionResult<User>> GetUserById([FromRoute] string userId)
        {
            var command = new GetUserCommand();
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [Route("user/{userId}")]
        public async Task<ActionResult> DeleteUser([FromRoute] string userId)
        {
            var command = new DeleteUserCommand();
            await _mediator.Send(command);
            return Ok();
        }
    }
}