namespace FinanceTracking.App.Views;

using ViewModels;

public partial class SettingsPage : ContentPage
{

	public SettingsPage()
	{
		InitializeComponent();

		this.InitializeComponent();

		this.BindingContext = new SettingsPageViewModel();
	}
}