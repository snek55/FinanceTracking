namespace FinanceTracking.Shared.Settings;

using Entities;
using Enums;
using Microsoft.AspNetCore.Components;

public partial class CurrencySettings
{
	private Currencies CurrentCurrency
	{
		get => this.Currency.CurType;
		set => this.Currency.CurType = value;
	}

	[Inject] private Currency Currency { get; set; }
}