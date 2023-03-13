using Azure;
using MediatR;
using MicroproyectoBackend.ApiRest.Request;
using MicroproyectoBackend.Aplication.Commands;
using MicroproyectoBackend.Infraestructure.Database;
using MicroproyectoBackend.Infraestructure.Entities;
using MicroproyectoBackend.Infraestructure.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MicroproyectoBackend.Aplication.CommandHandlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private UsersDbContext _userDbContext;

        public LoginCommandHandler(UsersDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }
        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userDbContext.Users.FirstAsync(x => x.Username == request.UserName);


            if (user == null || user.Pass != request.Password)
            {
                return null;
            }

            var claims = GetClaims(user.UserType);

            var token = GetToken(claims);
   
            return new LoginResponse() { Token = token, UserType = (int)user.UserType };
        }

        private List<Claim> GetClaims(int userType)
        {
            var claims = new List<Claim>();
            if (userType == (int)UserType.Admin)
            {
                claims.Add(new Claim(ClaimTypes.Role, "admin"));
            }

            return claims;
        }

        private string GetToken(List<Claim> claims)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("tu_clave_secreta"));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: "tu_issuer",
                audience: "tu_audience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signingCredentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return token;
        }
    }
}
