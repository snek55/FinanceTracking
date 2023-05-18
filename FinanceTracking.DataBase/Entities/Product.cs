namespace FinanceTracking.DataBase.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public decimal MinPrice { get; set; }
    public decimal MaxPrice { get; set; }
    public bool IsSolid { get; set; } = true;
    public int Volume { get; set; }
    public int Weight { get; set; }
}