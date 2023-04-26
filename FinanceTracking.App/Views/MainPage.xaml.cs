namespace FinanceTracking.App.Views;

public partial class MainPage : ContentPage
{
	int _count;

	public MainPage()
	{
		this.InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		this._count++;

		this.CounterBtn.Text = this._count == 1
			? $"Clicked {this._count} time"
			: $"Clicked {this._count} times";

		SemanticScreenReader.Announce(this.CounterBtn.Text);
	}
}