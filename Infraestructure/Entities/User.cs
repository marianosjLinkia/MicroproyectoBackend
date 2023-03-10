using MicroproyectoBackend.Infraestructure.Enums;

namespace MicroproyectoBackend.Infraestructure.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
    }
}