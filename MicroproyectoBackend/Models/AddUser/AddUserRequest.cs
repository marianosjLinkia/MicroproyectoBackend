using MicroproyectoBackend.Infraestructure.Enums;

namespace MicroproyectoBackend.ApiRest.Models.AddUser
{
    public class AddUserRequest
    {
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsAdmin { get; set; }
    }
}
