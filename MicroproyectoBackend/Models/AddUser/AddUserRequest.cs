using MicroproyectoBackend.Infraestructure.Enums;

namespace MicroproyectoBackend.ApiRest.Models.AddUser
{
    public class AddUserRequest
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Pass { get; set; }
        public UserType IsAdmin { get; set; }
    }
}
