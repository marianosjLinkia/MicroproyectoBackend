
using Azure;
using MediatR;
using MicroproyectoBackend.Aplication.Commands;
using MicroproyectoBackend.Infraestructure.Database;
using MicroproyectoBackend.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroproyectoBackend.Aplication.CommandHandlers
{
    public class GetUserCommandHandler : IRequestHandler<GetUserCommand, Users>
    {
        private UsersDbContext _userDbContext;

        public GetUserCommandHandler(UsersDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public async Task<Users> Handle(GetUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userDbContext.Users.FirstAsync(x => x.Id == request.Id);

            if (user == null)
            {
            }

            return user;
        }
    }
}
