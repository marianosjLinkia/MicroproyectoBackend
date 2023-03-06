using MediatR;
using MicroproyectoBackend.Aplication.Commands;
using MicroproyectoBackend.Infraestructure.Database;
using Microsoft.EntityFrameworkCore;

namespace MicroproyectoBackend.Aplication.CommandHandlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private UsersDbContext _userDbContext;
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userDbContext.User.FirstAsync(x => x.Id == request.UserId);

            if (user == null)
            {
                //throw NotFoundException();
            }

            _userDbContext.User.Remove(user);

            return Unit.Value;            
        }
    }
}
