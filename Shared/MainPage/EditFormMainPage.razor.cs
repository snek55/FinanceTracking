namespace FinanceTracking.Shared.MainPage
{
    using Entities;
    using Extensions;

    public partial class EditFormMainPage
    {
        private readonly Product _product = new();

        private void HandleValidSubmit()
        {
            TableMainPage.Products.Add(this._product.Clone<Product>());
        }
    }
}