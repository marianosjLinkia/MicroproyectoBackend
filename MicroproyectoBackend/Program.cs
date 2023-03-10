using MediatR;
using MicroproyectoBackend.Aplication.Commands;
using MicroproyectoBackend.Infraestructure.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Configuration;
using Microsoft.Extensions.Configuration;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var config = new ConfigurationBuilder();
        // Add services to the container.
        builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());
        //var connectionString = Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<UsersDbContext>(opciones =>
                 opciones.UseSqlServer("Server=tcp:linkiam12.database.windows.net,1433;Initial Catalog=ACT02;Persist Security Info=False;User ID=azureadmin;Password=rumae@12;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Application Name=myApp;"));
        builder.Services.AddMediatR(typeof(GetUserCommand));
        builder.Services.AddMediatR(typeof(GetUsersCommand));
        builder.Services.AddMediatR(typeof(DeleteUserCommand));
        builder.Services.AddMediatR(typeof(AddUserCommand));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}