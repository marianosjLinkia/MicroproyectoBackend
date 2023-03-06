
using Azure;
using MediatR;
using MicroproyectoBackend.Aplication.Commands;
using MicroproyectoBackend.Infraestructure.Database;
using MicroproyectoBackend.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroproyectoBackend.Aplication.CommandHandlers
{
    public class GetUserCommandHandler : IRequestHandler<GetUserCommand, User>
    {
        private UsersDbContext _userDbContext;
        public async Task<User> Handle(GetUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userDbContext.User.FirstAsync(x => x.Id == request.UserId);

            if (user == null)
            {
                //throw NotFoundException();
            }

            return user;
        }
    }
}
