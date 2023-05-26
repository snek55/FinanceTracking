using FinanceTracking.App.ViewModels;
using FinanceTracking.DataBase;

namespace FinanceTracking.App.Views;

public partial class AddProductPage : ContentPage
{
    private readonly FinanceTrackingDbContext _dbContext;
    private readonly AddProductPageViewModel _addProductPageViewModel;

    public AddProductPage(FinanceTrackingDbContext dbContext)
    {
        InitializeComponent();

        _dbContext = dbContext;
        _addProductPageViewModel = new AddProductPageViewModel();

        BindingContext = _addProductPageViewModel;
    }

    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        if (IsFieldsNotOk())
        {
            return;
        }

        await _dbContext.Products.AddAsync(_addProductPageViewModel.Product);
        await _dbContext.SaveChangesAsync();

        await Navigation.PopAsync();
    }

    private bool IsFieldsNotOk()
    {

        if (ProductNameValidator.IsNotValid)
        {
            DisplayAlert("Error", "Name is required", "Ok");
            return true;
        }
        
        if (ProductPriceValidator.IsNotValid)
        {
            DisplayAlert("Error", "Price must be more greater than zero", "Ok");
            return true;
        }
        
        if (ProductMeasureValidator.IsNotValid)
        {
            DisplayAlert("Error", "Measure value must be greater than zero", "Ok");
            return true;
        }

        return false;
    }
}