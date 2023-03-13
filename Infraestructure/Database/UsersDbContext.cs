using Azure.Core;
using MicroproyectoBackend.Infraestructure.Entities;
using MicroproyectoBackend.Infraestructure.Enums;
using Microsoft.EntityFrameworkCore;

namespace MicroproyectoBackend.Infraestructure.Database
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions options) : base(options)
        {
           
        }


        public DbSet<Users> Users { get; set; }        
    }
}