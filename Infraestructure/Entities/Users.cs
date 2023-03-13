using MicroproyectoBackend.Infraestructure.Enums;

namespace MicroproyectoBackend.Infraestructure.Entities
{
    public class Users
    {
            public int Id { get; set; }
            public string? Username { get; set; }
            public string? Fullname { get; set; }
            public string? Pass { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public int UserType { get; set; }

    }
}