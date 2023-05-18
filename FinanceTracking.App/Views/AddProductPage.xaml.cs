using FinanceTracking.DataBase;
using FinanceTracking.DataBase.Entities;

namespace FinanceTracking.App.Views;

public partial class AddProductPage : ContentPage
{
    public FinanceTrackingDbContext _dbContext { get; set; }
    
    private Product _product { get; set; }

    public AddProductPage(FinanceTrackingDbContext dbContext)
    {
        InitializeComponent();

        _dbContext = dbContext;
        _product = new Product();

        InitFields(_product.IsSolid);
    }

    private void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        _product.IsSolid = e.Value;
        InitFields(e.Value);
    }

    private void InitFields(bool isSolid)
    {
        SolidBox.IsChecked = isSolid;
        MeasureLabel.Text = isSolid ? "Weight:" : "Volume:";
        MeasureType.Text = isSolid ? "gram" : "milliliters";
    }

    private void OnSaveButtonClicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}