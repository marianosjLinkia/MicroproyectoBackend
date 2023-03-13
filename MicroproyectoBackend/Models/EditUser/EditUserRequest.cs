using MicroproyectoBackend.Infraestructure.Enums;

namespace MicroproyectoBackend.ApiRest.Models.EditUser
{
    public class EditUserRequest
    {
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Pass { get; set; }
        public UserType UserType { get; set; }

    }
}
