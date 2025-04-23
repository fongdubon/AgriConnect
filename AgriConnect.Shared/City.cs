using System.ComponentModel.DataAnnotations;

namespace AgriConnect.Shared
{
    public class City
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Ciudad")]
        [MaxLength(70, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        public string? Name { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
