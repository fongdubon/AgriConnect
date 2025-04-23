using AgriConnect.Mobile.ViewModel;

namespace AgriConnect.Mobile.Views;

public partial class ListadoColaboradores : ContentPage
{
	public ListadoColaboradores()
	{
		BindingContext = App.Current.Services.GetRequiredService<ColaboradoresViewModel>();
		InitializeComponent();
	}
}