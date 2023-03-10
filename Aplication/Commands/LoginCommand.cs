using MediatR;
using MicroproyectoBackend.Infraestructure.Entities;

namespace MicroproyectoBackend.Aplication.Commands
{
    public class LoginCommand : IRequest<string>
    {
        public string Email;
        public string Password;
    }
}
