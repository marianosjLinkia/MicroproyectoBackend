using MicroproyectoBackend.Infraestructure.Enums;

namespace MicroproyectoBackend.ApiRest.Models.EditUser
{
    public class EditUserRequest
    {
        public string Username;
        public string Fullname;
        public string Pass;
        public UserType UserType;
    }
}
