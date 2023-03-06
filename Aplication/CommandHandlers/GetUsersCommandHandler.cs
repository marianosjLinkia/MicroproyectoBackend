
//using MediatR;
//using MicroproyectoBackend.Aplication.Commands;
//using MicroproyectoBackend.Infraestructure.Database;
//using MicroproyectoBackend.Infraestructure.Entities;
//using Microsoft.EntityFrameworkCore;

//namespace MicroproyectoBackend.Aplication.CommandHandlers
//{
//    public class GetUsersCommandHandler : IRequestHandler<GetUsersCommand, List<User>>
//    {
//        private UsersDbContext _userDbContext;
//        public async Task<List<User>> Handle(GetUserCommand request, CancellationToken cancellationToken)
//        {
//            return await _userDbContext.User.ToListAsync();
//        }
//    }
//}
