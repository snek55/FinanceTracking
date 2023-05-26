using FinanceTracking.DataBase.Entities;

namespace FinanceTracking.App.ViewModels;

public class AddProductPageViewModel : BindableObject
{
    public Product Product { get; private set; }

    public AddProductPageViewModel()
    {
        Product = new Product();
    }
}