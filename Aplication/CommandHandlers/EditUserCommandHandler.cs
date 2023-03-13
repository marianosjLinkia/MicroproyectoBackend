
using Azure;
using MediatR;
using MicroproyectoBackend.Aplication.Commands;
using MicroproyectoBackend.Infraestructure.Database;
using MicroproyectoBackend.Infraestructure.Entities;
using MicroproyectoBackend.Infraestructure.Enums;
using Microsoft.EntityFrameworkCore;

namespace MicroproyectoBackend.Aplication.CommandHandlers
{
    public class EditUserCommandHandler : IRequestHandler<EditUserCommand, Unit>
    {
        private UsersDbContext _userDbContext;

        public EditUserCommandHandler(UsersDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }
        public async Task<Unit> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userDbContext.Users.FirstAsync(x => x.Id == request.Id);

            user.Username = request.Username;
            user.Pass = request.Pass;
            user.Fullname = request.Fullname;
            user.UserType = (int)request.UserType;

            _userDbContext.SaveChanges();

            return Unit.Value;
        }
    }
}
