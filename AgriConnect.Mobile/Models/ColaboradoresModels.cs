using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriConnect.Mobile.Models
{
    public class ColaboradoresModels
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public override string ToString()
        {
            return $"{Nombre} {Apellidos}";
        }
    }
}
