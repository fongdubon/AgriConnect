using AgriConnect.Shared;
using AgriConnect.Shared.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriConnect.Mobile.ViewModel
{
    public partial class ColaboradoresViewModel:ObservableObject
    {
        private ApiService apiService;
        public ObservableCollection<ColaboradoresModels> Colaboradores { get; set; } = new();
        [RelayCommand]
        public async Task ListarColaboradores()
        {
            this.apiService = new ApiService();
            Colaboradores.Clear();
            var url = "https://localhost:7061/";
            var response = await this.apiService.GetListAsync<City>(
                url,
                "/api",
                "/Cities");
            if (!response.IsSuccess)
            {   
                return;
            }
            var myCities = (List<City>)response.Result;
            foreach (var city in myCities)
            {
                Colaboradores.Add(new ColaboradoresModels() { Nombre = city.Id.ToString(), Apellidos = city.Name});
            }
            /*Colaboradores.Add(new ColaboradoresModels() { Nombre = "Humidity: 74.60", Apellidos = " - Temperature: 28.90" });
            Colaboradores.Add(new ColaboradoresModels() { Nombre = "Humidity: 73.30", Apellidos = " - Temperature: 28.60" });
            Colaboradores.Add(new ColaboradoresModels() { Nombre = "Humidity: 69.90", Apellidos = " - Temperature: 28.30" });
            Colaboradores.Add(new ColaboradoresModels() { Nombre = "Humidity: 66.10", Apellidos = " - Temperature: 28.10" });
            Colaboradores.Add(new ColaboradoresModels() { Nombre = "Humidity: 62.70", Apellidos = " - Temperature: 28.10" });
            Colaboradores.Add(new ColaboradoresModels() { Nombre = "Humidity: 59.40", Apellidos = " - Temperature: 28.00" });
            Colaboradores.Add(new ColaboradoresModels() { Nombre = "Humidity: 56.00", Apellidos = " - Temperature: 28.00" });
            Colaboradores.Add(new ColaboradoresModels() { Nombre = "Humidity: 57.00", Apellidos = " - Temperature: 28.10" }); Colaboradores.Add(new ColaboradoresModels() { Nombre = "Humidity: 74.60", Apellidos = " - Temperature: 28.90" });
            Colaboradores.Add(new ColaboradoresModels() { Nombre = "Humidity: 73.30", Apellidos = " - Temperature: 28.60" });
            Colaboradores.Add(new ColaboradoresModels() { Nombre = "Humidity: 69.90", Apellidos = " - Temperature: 28.30" });
            Colaboradores.Add(new ColaboradoresModels() { Nombre = "Humidity: 66.10", Apellidos = " - Temperature: 28.10" });
            Colaboradores.Add(new ColaboradoresModels() { Nombre = "Humidity: 62.70", Apellidos = " - Temperature: 28.10" });
            Colaboradores.Add(new ColaboradoresModels() { Nombre = "Humidity: 59.40", Apellidos = " - Temperature: 28.00" });
            Colaboradores.Add(new ColaboradoresModels() { Nombre = "Humidity: 56.00", Apellidos = " - Temperature: 28.00" });
            Colaboradores.Add(new ColaboradoresModels() { Nombre = "Humidity: 57.00", Apellidos = " - Temperature: 28.10" });
            //Colaboradores.Add(new ColaboradoresModels() { Nombre = "Brad", Apellidos = "Pitt" });
            //Colaboradores.Add(new ColaboradoresModels() { Nombre = "Tom", Apellidos = "Cruise" });
            //Colaboradores.Add(new ColaboradoresModels() { Nombre = "Angelina", Apellidos = "Jolie" });
            //Colaboradores.Add(new ColaboradoresModels() { Nombre = "Jennifer", Apellidos = "López" });
            //Colaboradores.Add(new ColaboradoresModels() { Nombre = "John", Apellidos = "Doe" });
            //Colaboradores.Add(new ColaboradoresModels() { Nombre = "Jane", Apellidos = "Doe" });
            */
        }
    }
}
