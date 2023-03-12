using MediatR;
using MicroproyectoBackend.Infraestructure.Enums;

namespace MicroproyectoBackend.Aplication.Commands
{
    public class AddUserCommand : IRequest
    {
        public string Fullname;
        public string Username;
        public string Pass;
        public UserType IsAdmin;
    } 
}
