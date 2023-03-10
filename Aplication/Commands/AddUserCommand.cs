using MediatR;
using MicroproyectoBackend.Infraestructure.Enums;

namespace MicroproyectoBackend.Aplication.Commands
{
    public class AddUserCommand : IRequest
    {
        public string Username;
        public string Fullname;
        public byte[] Pass;
        public DateTime StartDate;
        public DateTime EndDate;
        public bool IsAdmin;

    }
}
