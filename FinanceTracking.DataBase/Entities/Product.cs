namespace FinanceTracking.DataBase.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public decimal Cost { get; set; }
    public bool IsSolid { get; set; }
    public int Weight { get; set; }
}