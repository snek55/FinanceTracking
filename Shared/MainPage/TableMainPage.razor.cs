namespace FinanceTracking.Shared.MainPage;

using Entities;
using Enums;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.ObjectModel;

public partial class TableMainPage
{
	private ObservableCollection<Shopping> _shopping;

	[Inject]
	private ObservableCollection<Shopping> Shopping
	{
		get => this._shopping;
		set
		{
			this._shopping = value;
			this.BindCollection();
		}
	}

	[Inject]
	private Currency CurrentCurrency { get; set; }

	private static char CurrencySymbol(Currencies currencies)
	{
		return currencies switch
		{
			Currencies.AUD or Currencies.CAD or Currencies.USD => '$',
			Currencies.RUB => '₽',
			Currencies.EUR => '€',
			_ => throw new NotImplementedException()
		};
	}

	private void BindCollection()
	{
		this._shopping.CollectionChanged += (_, _) => this.StateHasChanged();
	}

	private static string GetUnitsMeasurement(ProductMeasurement productMeasurement)
	{
		return productMeasurement switch
		{
			ProductMeasurement.Volume => "l",
			ProductMeasurement.Weight => "kg",
			_ => "pcs"
		};
	}
}