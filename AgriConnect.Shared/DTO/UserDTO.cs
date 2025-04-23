using System.ComponentModel.DataAnnotations;

namespace AgriConnect.Shared.DTO
{
    public class UserDTO:User
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(30, ErrorMessage = "El campo {0} debe tener máximo {1} caracter")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(30, ErrorMessage = "El campo {0} debe tener máximo {1} caracter")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Contraseñas no coinciden")]
        [Display(Name = "Confirmar contraseña")]
        public string? PasswordConfirm { get; set; }
    }
}
