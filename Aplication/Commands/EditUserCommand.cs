using MediatR;
using MicroproyectoBackend.Infraestructure.Enums;

namespace MicroproyectoBackend.Aplication.Commands
{
    public class EditUserCommand : IRequest
    {
        public int Id;
        public string Username;
        public string Fullname;
        public string Pass;
        public bool IsAdmin;
        public string Email;


    }
}
