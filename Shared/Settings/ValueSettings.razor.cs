namespace FinanceTracking.Shared.Settings
{
	using FinanceTracking.Entities;
	using FinanceTracking.Enums;
	using Microsoft.AspNetCore.Components;

	public partial class ValueSettings
	{
		private Currencies CurrentCurrency 
		{
			get => this.currentCurrency.CurType;
			set => this.currentCurrency.CurType = value;
		}

		[Inject]
		private Currency currentCurrency { get; set; }
	}
}
