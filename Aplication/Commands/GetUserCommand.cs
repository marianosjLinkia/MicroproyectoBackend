using MediatR;
using MicroproyectoBackend.Infraestructure.Entities;

namespace MicroproyectoBackend.Aplication.Commands
{
    public class GetUserCommand : IRequest<Users>
    {
        public int Id;
    }
}
