namespace AgriConnect.Mobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ListadoColaboradores), typeof(ListadoColaboradores));
            Routing.RegisterRoute(nameof(Colaborador), typeof(Colaborador));
        }
    }
}
