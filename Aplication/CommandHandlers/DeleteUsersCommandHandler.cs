using MediatR;
using MicroproyectoBackend.Aplication.Commands;
using MicroproyectoBackend.Infraestructure.Database;
using Microsoft.EntityFrameworkCore;

namespace MicroproyectoBackend.Aplication.CommandHandlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private UsersDbContext _userDbContext;

        public DeleteUserCommandHandler(UsersDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userDbContext.Users.FirstAsync(x => x.Id == request.Id); 
            
            if (user == null)
            {
                //throw NotFoundException();
            }
            
            _userDbContext.Users.Remove(user);

            return Unit.Value;
        }
    }
}
