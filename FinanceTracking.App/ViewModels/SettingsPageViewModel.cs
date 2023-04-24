namespace FinanceTracking.App.ViewModels;

using System.Text.Json.Serialization;

public class SettingsPageViewModel : BindableObject
{
	[JsonIgnore]
	public static readonly BindableProperty DefaultCurrencyProperty = BindableProperty.Create(
		nameof(DefaultCurrency), typeof(string), typeof(SettingsPageViewModel));

	[JsonIgnore]
	public static readonly BindableProperty DefaultLanguageProperty = BindableProperty.Create(
		nameof(DefaultLanguage), typeof(string), typeof(SettingsPageViewModel));

	public string DefaultCurrency
	{
		get => (string)this.GetValue(DefaultCurrencyProperty);
		set => this.SetValue(DefaultCurrencyProperty, value);
	}

	public string DefaultLanguage
	{
		get => (string)this.GetValue(DefaultLanguageProperty);
		set => this.SetValue(DefaultLanguageProperty, value);
	}

	public List<string> Currencies { get; set; } = new() { "Euro", "US Dollar" };
	public List<string> Languages { get; set; } = new() { "English" };

	public SettingsPageViewModel()
	{
		this.DefaultCurrency = this.Currencies.First();
		this.DefaultLanguage = this.Languages.First();
	}
}