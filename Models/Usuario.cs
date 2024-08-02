using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
    }
}
