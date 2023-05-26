namespace FinanceTracking.App.Views;

using System.Text.Json;
using ViewModels;

public partial class SettingsPage : ContentPage
{
	private string SettingsPath { get; set; }
	private const string SettingsFileName = "UserSettings.txt";

	public SettingsPage()
	{
		InitializeComponent();

		SettingsPath = Path.Combine(FileSystem.Current.AppDataDirectory, SettingsFileName);
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();

		var settings = await LoadData();

		BindingContext = settings;
	}

	private async Task<SettingsPageViewModel> LoadData()
	{
		if (!File.Exists(SettingsPath))
		{
			return await CreateFile();
		}

		using var reader = new StreamReader(SettingsPath);
		var data = await reader.ReadToEndAsync();

		var settings = JsonSerializer.Deserialize<SettingsPageViewModel>(data);

		return settings;
	}

	private async Task<SettingsPageViewModel> CreateFile()
	{
		await using StreamWriter writer = new(SettingsPath);

		var settings = new SettingsPageViewModel();

		var json = JsonSerializer.Serialize(settings);

		await writer.WriteLineAsync(json);

		return settings;
	}

	async void OnSaveClicked(object sender, EventArgs args)
	{
		await using var outputStream = File.OpenWrite(SettingsPath);
		await using var streamWriter = new StreamWriter(outputStream);

		var json = JsonSerializer.Serialize(BindingContext);

		await streamWriter.WriteAsync(json);
	}
}