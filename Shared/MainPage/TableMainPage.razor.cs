namespace FinanceTracking.Shared.MainPage
{
    using System.Collections.ObjectModel;
    using Entities;
    using Enums;
    using Extensions;

    public partial class TableMainPage
    {
        private static ObservableCollection<Shopping> Shopping { get; } = new();

        public TableMainPage()
        {
            Shopping.CollectionChanged += (_, _) => this.StateHasChanged();
        }

        public void AddTableListElement(Shopping product) {
            var newItem = product.Clone<Shopping>();

            Shopping.Add(newItem);
        }

        private string GetUnitsMeasurement(ProductMeasurement productMeasurement) {
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