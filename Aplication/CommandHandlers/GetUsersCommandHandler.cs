
using MediatR;
using MicroproyectoBackend.Aplication.Commands;
using MicroproyectoBackend.Infraestructure.Database;
using MicroproyectoBackend.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroproyectoBackend.Aplication.CommandHandlers
{
    public class GetUsersCommandHandler : IRequestHandler<GetUsersCommand, List<Users>>
    {
        private UsersDbContext _userDbContext;

        public GetUsersCommandHandler(UsersDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public async Task<List<Users>> Handle(GetUsersCommand request, CancellationToken cancellationToken)
        {
            return await _userDbContext.Users.ToListAsync();
        }
    }
}
