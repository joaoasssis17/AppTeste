using AppTeste.ViewModels;

namespace AppTeste.Views;

public partial class CoinView : ContentPage
{
	public CoinView()
	{
		InitializeComponent();
		this.BindingContext =  new CoinViewModel();
	}
}