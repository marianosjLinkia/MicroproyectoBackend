using MediatR;
using MicroproyectoBackend.Infraestructure.Entities;

namespace MicroproyectoBackend.Aplication.Commands
{
    public class GetUsersCommand : IRequest<List<Users>>
    {
    }
}
