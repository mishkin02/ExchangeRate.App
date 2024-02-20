using ExchangeRate.ViewModel;

namespace ExchangeRate;

public partial class MainPage : ContentPage
{
	public MainPage(ValutesViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}

