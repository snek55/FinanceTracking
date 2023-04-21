namespace FinanceTracking.App;

public partial class App : Application
{
	public App()
	{
		this.InitializeComponent();

		this.MainPage = new AppShell();
	}
}