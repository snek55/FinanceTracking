using Microsoft.Extensions.Logging;
using DevExpress.Maui;
using FinanceTracking.App.Views;
using FinanceTracking.DataBase;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracking.App;

public static class MauiProgram
{ 
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseDevExpress()
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.InitServices();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

	private static void InitServices(this MauiAppBuilder builder)
	{
		builder.Services.AddSingleton<ProductsPage>();
		builder.Services.AddSingleton<AddProductPage>();
		builder.Services.AddDbContext<FinanceTrackingDbContext>(option =>
			option.UseSqlite($"FileName={GetStr()}",
				x => x.MigrationsAssembly("FinanceTracking.DataBase")));
	}

	private static string GetStr()
	{
		var dataBasePath = "";
		var dataBaseName = "FinanceTrackingDb.db3";

		if (DeviceInfo.Platform == DevicePlatform.Android)
		{
			dataBasePath = Path.Combine(FileSystem.AppDataDirectory, dataBaseName);
		}

		if (DeviceInfo.Platform == DevicePlatform.iOS)
		{
			SQLitePCL.Batteries_V2.Init();
			dataBasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..",
				"Library", dataBaseName);
		}

		return dataBasePath;
	}
}