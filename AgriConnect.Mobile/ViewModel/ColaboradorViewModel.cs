using AgriConnect.Shared;
using AgriConnect.Shared.Entities;
using AgriConnect.Shared.Services;
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
            /*ValidateAllProperties();
            Errors.Clear();
            GetErrors(nameof(Nombre)).ToList().ForEach(f => Errors.Add("Nombre" + f.ErrorMessage));
            GetErrors(nameof(Apellidos)).ToList().ForEach(f => Errors.Add("Apellidos" + f.ErrorMessage));*/
            if (string.IsNullOrEmpty(this.Nombre))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debe introducir un nombre.", "Acceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.Apellidos))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debe introducir los apellidos.", "Acceptar");
                return;
            }
            ApiService apiService = new ApiService();
            var request = new TokenRequest
            {
                Password = "123456",
                Email = "brad.pitt@gmail.com"
            };
            var url = "https://localhost:7061/";

            var response = await apiService.LoginAsync(
                url,
                "/api/Accounts",
                "/Login",
                request);
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Email o contraseña incorrecta.", "Acceptar");
                return;
            }
            var token = (TokenResponse)response.Result;
            
            
            var city = new City
            {
                Name = this.Nombre,
            };
            response = await apiService.PostAsync(
                url,
                "/api",
                "/Cities",
                city,
                "bearer",
                token.Token);
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Acceptar");
                return;
            }
            //var errorNombre = GetErrors(nameof(Nombre)).ToList();
            //var errorApellidos = GetErrors(nameof(Apellidos)).ToList();
        }
    }
}
