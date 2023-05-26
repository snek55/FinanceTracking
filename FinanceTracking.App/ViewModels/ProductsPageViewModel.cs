using FinanceTracking.DataBase.Entities;

namespace FinanceTracking.App.ViewModels;

public class ProductsPageViewModel : BindableObject
{
    public static readonly BindableProperty ProductProperty = BindableProperty.Create(
        nameof(Products), typeof(List<Product>), typeof(ProductsPageViewModel));

    public List<Product> Products
    {
        get => (List<Product>)GetValue(ProductProperty);
        set => SetValue(ProductProperty, value);
    }
}