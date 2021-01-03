namespace FinanceTracking.Shared.MainPage
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Entities;
    using System.Linq;

    public partial class TableMainPage
    {
        public static ObservableCollection<Product> Products { get; } = new();

        public TableMainPage()
        {
            Products.CollectionChanged += (_, _) =>
            {
                this.StateHasChanged();
            };
        }
    }
}