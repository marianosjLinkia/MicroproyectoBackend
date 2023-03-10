using MediatR;
using MicroproyectoBackend.Infraestructure.Entities;

namespace MicroproyectoBackend.Aplication.Commands
{
    public class DeleteUserCommand : IRequest
    {
        public int Id;
    }
}
