
using Azure;
using MediatR;
using MicroproyectoBackend.Aplication.Commands;
using MicroproyectoBackend.Infraestructure.Database;
using MicroproyectoBackend.Infraestructure.Entities;
using MicroproyectoBackend.Infraestructure.Enums;

namespace MicroproyectoBackend.Aplication.CommandHandlers
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, Unit>
    {
        private UsersDbContext _userDbContext;

        public AddUserCommandHandler(UsersDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public async Task<Unit> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = new Users()
            {
                Username = request.Username,
                Pass = request.Pass,
                Fullname = request.Fullname,
                UserType = (int)request.UserType,
            };

            _userDbContext.Users.Add(user);
            _userDbContext.SaveChanges();
            return Unit.Value;
        }
    }
}
