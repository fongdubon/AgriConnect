
namespace AgriConnect.Mobile.Views;

public partial class Colaborador : ContentPage
{
	public Colaborador()
	{
		BindingContext = App.Current.Services.GetRequiredService<ColaboradorViewModel>();
        InitializeComponent();
	}
}