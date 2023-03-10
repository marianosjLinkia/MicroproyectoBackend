
using Azure;
using MediatR;
using MicroproyectoBackend.Aplication.Commands;
using MicroproyectoBackend.Infraestructure.Database;
using MicroproyectoBackend.Infraestructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MicroproyectoBackend.Aplication.CommandHandlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private UsersDbContext _userDbContext;
        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var userInDb = await _userDbContext.User.FirstAsync(x => x.Email == request.Email);

            if (userInDb == null || userInDb.Password != request.Password)
            {
                return null;
            }
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("tu_clave_secreta"));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: "tu_issuer",
                audience: "tu_audience",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signingCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return tokenString;
        }
    }
    
}
