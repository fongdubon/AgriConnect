using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace AgriConnect.Shared.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(30, ErrorMessage = "El campo {0} debe tener máximo {1} caracter")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }= null!;
    }
}
