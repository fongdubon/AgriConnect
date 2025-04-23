using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriConnect.Mobile.ViewModel
{
    public partial class ColaboradorViewModel:ObservableValidator
    {
        public ObservableCollection<string> Errors { get; set; }= new();
        private string nombre;
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(10,ErrorMessage = "El campo {0} debe tener Máximo {1} caracteres")]
        public string Nombre
        {
            get => nombre;
            set => SetProperty(ref nombre, value, true);
        }
        private string apellidos;
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(10, ErrorMessage = "El campo {0} debe tener Máximo {1} caracteres")]

        public string Apellidos
        {
            get => apellidos;
            set => SetProperty(ref apellidos, value, true);
        }
        [RelayCommand]
        public async Task GuardarColaborador()
        {
            ValidateAllProperties();
            Errors.Clear();
            GetErrors(nameof(Nombre)).ToList().ForEach(f => Errors.Add("Nombre" + f.ErrorMessage));
            GetErrors(nameof(Apellidos)).ToList().ForEach(f => Errors.Add("Apellidos" + f.ErrorMessage));
            //var errorNombre = GetErrors(nameof(Nombre)).ToList();
            //var errorApellidos = GetErrors(nameof(Apellidos)).ToList();
        }
    }
}
