namespace AgriConnect.Mobile.Services
{
    public class Functions : IFunctions
    {
        public string CambiarTexto(string texto, int count) => $"{texto} - {count}";

    }
}
