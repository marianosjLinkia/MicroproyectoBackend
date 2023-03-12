using Azure.Core;
using MediatR;
using MicroproyectoBackend.ApiRest.Models.AddUser;
using MicroproyectoBackend.ApiRest.Models.EditUser;
using MicroproyectoBackend.Aplication.Commands;
using MicroproyectoBackend.Infraestructure.Entities;
using MicroproyectoBackend.Infraestructure.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroproyectoBackend.ApiRest.Controllers
{
    
    
    [Route("api/users")]
    [ApiController]
    [Authorize (Policy = "AdminOnly")]
    public class UsersController : ControllerBase
    {       

        private readonly ILogger<UsersController> _logger;
        private readonly IMediator _mediator;

        public UsersController(ILogger<UsersController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;            
        }

        [HttpPost]
        [Route("addUser")]
        public async Task<ActionResult> AddUser([FromBody] AddUserRequest request)
        {            
            var command = new AddUserCommand()
            {               
                Username = request.Username,
                Fullname = request.Fullname,
                Pass = request.Pass,        
                IsAdmin = request.IsAdmin
            };

            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [Route("user")]
        public async Task<ActionResult<List<Users>>> GetUsers()
        {            
            var command = new GetUsersCommand();
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [Route("user/{userId}")]
        public async Task<ActionResult<Users>> GetUserById([FromRoute] int userId)
        {
            var command = new GetUserCommand { Id = userId};
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [Route("user/{userId}")]
        public async Task<ActionResult> DeleteUser([FromRoute] int userId)
        {
            var command = new DeleteUserCommand { Id = userId };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        [Route("user/{userId}")]
        public async Task<ActionResult> UpdateUser([FromRoute] int userId, [FromBody] EditUserRequest request)
        {
            var command = new EditUserCommand()
            {
                Username = request.Username,
                Fullname = request.Fullname,
                Pass = request.Pass,
                IsAdmin = request.IsAdmin
            };
            command.Id = userId;

            await _mediator.Send(command);

            return Ok();
        }
    }
}