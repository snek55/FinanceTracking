namespace FinanceTracking.App.ViewModels;

public class SettingsPageViewModel : BindableObject
{
	public static readonly BindableProperty DefaultCurrencyProperty = BindableProperty.Create(
		nameof(DefaultCurrency), typeof(string), typeof(SettingsPageViewModel));

	public string DefaultCurrency
	{
		get => (string)this.GetValue(DefaultCurrencyProperty);
		set => this.SetValue(DefaultCurrencyProperty, value);
	}

	public List<string> Currencies { get; } = new() { "Euro", "US Dollar" };

	public SettingsPageViewModel()
	{
		this.DefaultCurrency = this.Currencies.First();
	}
}