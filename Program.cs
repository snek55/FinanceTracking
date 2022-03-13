namespace FinanceTracking;

using Blazored.LocalStorage;
using Entities;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

public class Program
{
	public static async Task Main(string[] args)
	{
		WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
		builder.RootComponents.Add<App>("#app");

		RegisterServices(builder);

		await builder.Build().RunAsync();
	}

	private static void RegisterServices(WebAssemblyHostBuilder builder)
	{
		builder.Services.AddBlazoredLocalStorage();

		builder.Services.AddSingleton(new ObservableCollection<Shopping>());
		builder.Services.AddSingleton(new Currency());
		builder.Services.AddSingleton<IDataService, MockDataService>();

		builder.Services.AddScoped<IStatisticService, StatisticService>();
		builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
	}
}