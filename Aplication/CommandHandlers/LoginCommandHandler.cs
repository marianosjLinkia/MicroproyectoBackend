
using Azure;
using MediatR;
using MicroproyectoBackend.Aplication.Commands;
using MicroproyectoBackend.Infraestructure.Database;
using MicroproyectoBackend.Infraestructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MicroproyectoBackend.Aplication.CommandHandlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private UsersDbContext _userDbContext;
        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var userInDb = await _userDbContext.User.FirstAsync(x => x.Email == request.Email);
            
            return null;
        }
    }
    
}
