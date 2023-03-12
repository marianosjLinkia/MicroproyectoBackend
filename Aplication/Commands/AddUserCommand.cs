using MediatR;
using MicroproyectoBackend.Infraestructure.Enums;

namespace MicroproyectoBackend.Aplication.Commands
{
    public class AddUserCommand : IRequest
    {
        public int Id;
        public string Username;
        public string Fullname;
        public string Email;
        public string Pass;
        public DateTime StartDate;
        public DateTime? EndDate;
        public bool IsAdmin;
    } 
}
