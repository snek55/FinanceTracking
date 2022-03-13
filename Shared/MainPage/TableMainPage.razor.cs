namespace FinanceTracking.Shared.MainPage
{
	using System.Collections.ObjectModel;
	using Entities;
	using Enums;
	using Microsoft.AspNetCore.Components;

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
		private Currency currentCurrency { get; set; }

		private void BindCollection()
        {
            this._shopping.CollectionChanged += (_, _) => this.StateHasChanged();
        }

		private string GetUnitsMeasurement(ProductMeasurement productMeasurement)
		{
			switch (productMeasurement)
			{
				case ProductMeasurement.Volume:
					return "l";
				case ProductMeasurement.Weight:
					return "kg";
				default:
					return "pcs";
			}
		}
	}
}