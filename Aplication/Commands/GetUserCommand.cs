using MediatR;
using MicroproyectoBackend.Infraestructure.Entities;

namespace MicroproyectoBackend.Aplication.Commands
{
    public class GetUserCommand : IRequest<User>
    {
        public int UserId;
    }
}
