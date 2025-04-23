using AgriConnect.Mobile.Services;
using AgriConnect.Mobile.ViewModel;

namespace AgriConnect.Mobile
{
    public partial class App : Application
    {
        public new static App Current => (App)Application.Current;
        public IServiceProvider Services { get; }
        public App()
        {
            var services = new ServiceCollection();
            Services = ConfigureServices(services);
            InitializeComponent();
            //MainPage = new NavigationPage(new Pages.LoginPage());
            MainPage = new AppShell();
        }
        private static IServiceProvider ConfigureServices(ServiceCollection services)
        {
            //Servicios 
            services.AddSingleton<IFunctions, Functions>();
            
            //ViewModels
            services.AddTransient<ViewModelTest>();
            services.AddTransient<ColaboradoresViewModel>();
            services.AddTransient<ColaboradorViewModel>();

            //View
            services.AddSingleton<ListadoColaboradores>();
            services.AddSingleton<Colaborador>();

            return services.BuildServiceProvider();
        }
    }
}
