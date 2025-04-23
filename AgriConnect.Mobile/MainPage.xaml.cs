using AgriConnect.Mobile.ViewModel;

namespace AgriConnect.Mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = App.Current.Services.GetRequiredService<ViewModelTest>();
            InitializeComponent();
        }

    }

}
