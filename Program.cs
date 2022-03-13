using Blazored.LocalStorage;
using FinanceTracking;
using FinanceTracking.Entities;
using FinanceTracking.Services;
using FinanceTracking.Services.Interfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddSingleton(new ObservableCollection<Shopping>());
builder.Services.AddSingleton<Currency>();
builder.Services.AddSingleton<IDataService, MockDataService>();

builder.Services.AddScoped<IStatisticService, StatisticService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();