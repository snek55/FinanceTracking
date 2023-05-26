using FinanceTracking.App.ViewModels;
using FinanceTracking.DataBase;

namespace FinanceTracking.App.Views;

public partial class ProductsPage : ContentPage
{
	private readonly FinanceTrackingDbContext _dbContext;
	private readonly ProductsPageViewModel _productsPageViewModel;
	private readonly AddProductPage _addProductPage;

	public ProductsPage(AddProductPage addProductPage, FinanceTrackingDbContext dbContext)
	{
		InitializeComponent();

		_addProductPage = addProductPage;
		_dbContext = dbContext;
		_productsPageViewModel = new ProductsPageViewModel();

		BindingContext = _productsPageViewModel;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();

		_productsPageViewModel.Products = _dbContext.Products.ToList();
	}

	private async void OnAddClicked(object sender, EventArgs e)
	{
		_addProductPage.BindingContext = new AddProductPageViewModel
		{
			Product = {Name = ProductNameEntry.Text}
		};

		await Navigation.PushAsync(_addProductPage);
	}

	private void OnSearch(object sender, TextChangedEventArgs e)
	{
		var productsList = _dbContext.Products
			.Where(w => w.Name.Contains(e.NewTextValue))
			.ToList();

		_productsPageViewModel.Products = productsList;
	}
}