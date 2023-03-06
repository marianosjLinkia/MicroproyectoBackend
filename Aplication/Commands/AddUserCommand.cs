using MediatR;
using MicroproyectoBackend.Infraestructure.Enums;

namespace MicroproyectoBackend.Aplication.Commands
{
    public class AddUserCommand : IRequest
    {
        public string Name;
        public UserType UserType;
    }
}
