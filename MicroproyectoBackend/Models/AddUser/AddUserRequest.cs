using MicroproyectoBackend.Infraestructure.Enums;

namespace MicroproyectoBackend.ApiRest.Models.AddUser
{
    public class AddUserRequest
    {
        public string Username;
        public string Fullname;
        public string Pass;
        public UserType UserType;
    }
}
