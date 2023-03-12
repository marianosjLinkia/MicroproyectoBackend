using MediatR;
using MicroproyectoBackend.ApiRest.Request;
using MicroproyectoBackend.Infraestructure.Entities;

namespace MicroproyectoBackend.Aplication.Commands
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        public string UserName;
        public string Password;
    }
}
